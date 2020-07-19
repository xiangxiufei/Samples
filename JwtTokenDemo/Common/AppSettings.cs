using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Core
{
    public class AppSettings
    {
        private static readonly IConfigurationRoot configuration;

        static AppSettings()
        {
            configuration = new ConfigurationBuilder()
                               .SetBasePath(Directory.GetCurrentDirectory())
                               .AddJsonFile("appsettings.json", false, true)
                               .Build();
        }

        public static class JWT
        {
            public static string Issuer => configuration["JWT:Issuer"];
            public static string AccessTokenAudience => configuration["JWT:AccessTokenAudience"];
            public static int AccessTokenExpires => Convert.ToInt32(configuration["JWT:AccessTokenExpires"]);
            public static string RefreshTokenAudience => configuration["JWT:RefreshTokenAudience"];
            public static int RefreshTokenExpires => Convert.ToInt32(configuration["JWT:RefreshTokenExpires"]);
            public static string SecurityKey => configuration["JWT:SecurityKey"];
        }
    }
}