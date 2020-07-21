using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Core.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StudentController : ControllerBase
    {
        public static readonly List<Student> students = new List<Student>()
        {
            new Student(){Account="1001", Password="123456", Name="张三",Sex="男",Age=25 },
            new Student(){Account="1002", Password="123456", Name="李四",Sex="男",Age=24 },
            new Student(){Account="1003", Password="123456", Name="王五",Sex="男",Age=23 }
        };

        [HttpGet]
        public Response<JwtDto> Login(string account, string password)
        {
            var response = new Response<JwtDto>();

            var user = students.SingleOrDefault(t => t.Account == account);

            if (user != null)
            {
                if (user.Password.Equals(password))
                {
                    response.Msg = "登录成功";

                    var token = new JwtDto()
                    {
                        AccessToken = Jwt.CreateToken(user, TokenType.AccessToken),
                        RefreshToken = Jwt.CreateToken(user, TokenType.RefreshToken)
                    };

                    response.Data = token;
                }
                else
                {
                    response.Status = 400;
                    response.Msg = "用户密码不正确！";
                }
            }
            else
            {
                response.Status = 400;
                response.Msg = "用户名不存在！";
            }

            return response;
        }

        [HttpGet]
        public Response<string> RefreshToken(string refreshToken)
        {
            Student student;
            var response = new Response<string>();

            if (Jwt.ValidateRefreshToken(refreshToken.ToStringX().Replace("Bearer ", ""), out student))
            {
                response.Data = Jwt.CreateToken(student, TokenType.AccessToken);
            }
            else
            {
                response.Status = 401;
                response.Msg = "Unauthorized";
            }

            return response;
        }

        [HttpGet]
        [Authorize]
        public Response<string> JwtTokenTest()
        {
            var result = new Response<string>();

            return result;
        }
    }
}
