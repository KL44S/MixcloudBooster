using System.IO;
using Microsoft.Extensions.Configuration;

namespace MixcloudBooster
{
    public class ConfigurationFactory
    {
        private static IConfiguration Configuration;

        public static IConfiguration GetConfiguration()
        {
            if (Configuration == null)
            {
                SetConfiguration();
            }

            return Configuration;
        }

        private static void SetConfiguration()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            Configuration = builder.Build();
        }
    }
}
