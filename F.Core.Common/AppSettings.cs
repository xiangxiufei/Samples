using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace F.Core.Common
{
    public class AppSettings
    {
        public static IConfiguration Configuration { get; set; }

        static AppSettings()
        {
            Configuration = new ConfigurationBuilder()
               .Add(new JsonConfigurationSource { Path = "appsettings.json", ReloadOnChange = true })
               .Build();
        }
    }
}