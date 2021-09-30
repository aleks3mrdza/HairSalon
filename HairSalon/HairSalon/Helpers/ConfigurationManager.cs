using Microsoft.Extensions.Configuration;
using System.IO;

namespace HairSalon.Helpers
{
    public class ConfigurationManager
    {
        public static IConfiguration appSettings { get; }

        static ConfigurationManager()
        {
            appSettings = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
        }

        public static string GetSetting(string name)
        {
            return appSettings[name];
        }
    }
}
