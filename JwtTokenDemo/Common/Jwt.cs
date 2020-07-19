using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core
{
    public class Jwt
    {
        public static string CreateToken(Student student, TokenType type)
        {
            var audience = type == TokenType.AccessToken ? AppSettings.JWT.AccessTokenAudience : AppSettings.JWT.RefreshTokenAudience;

            var expires = type == TokenType.AccessToken ? AppSettings.JWT.AccessTokenExpires : AppSettings.JWT.RefreshTokenExpires;

            var claims = new Claim[] {
                    new Claim(ClaimTypes.Name, student.Account),
                    new Claim(JwtRegisteredClaimNames.Iss,AppSettings.JWT.Issuer),
                    new Claim(JwtRegisteredClaimNames.Aud,audience),
                    new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                    new Claim(JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddSeconds(expires)).ToUnixTimeSeconds()}")
                };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JWT.SecurityKey));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var securityToken = new JwtSecurityToken(
                    issuer: AppSettings.JWT.Issuer,
                    audience: audience,
                    claims: claims,
                    expires: DateTime.Now.AddSeconds(expires),
                    signingCredentials: signingCredentials);

            return "Bearer " + new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

        public static bool ValidateRefreshToken(string refreshToken, out Student student)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = AppSettings.JWT.Issuer,
                ValidateAudience = true,
                ValidAudience = AppSettings.JWT.RefreshTokenAudience,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0),
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppSettings.JWT.SecurityKey))
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken;

            try
            {
                tokenHandler.ValidateToken(refreshToken, tokenValidationParameters, out securityToken);
                student = SerializeToken(securityToken);

                return true;
            }
            catch (Exception)
            {
                student = null;
                return false;
            }
        }

        public static Student SerializeToken(SecurityToken securityToken)
        {
            Student student = new Student();

            object account;

            (securityToken as JwtSecurityToken).Payload.TryGetValue(ClaimTypes.Name, out account);

            student.Account = account.ToString();

            return student;
        }
    }

    public enum TokenType
    {
        AccessToken,
        RefreshToken
    }

    public class JwtDto
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}