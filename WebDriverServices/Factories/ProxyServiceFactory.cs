using DataAccessServices;
using Microsoft.Extensions.Configuration;

namespace WebDriverServices.Factories
{
    public class ProxyServiceFactory
    {
        public static IProxyService BuildAndGetBoostUser(IConfiguration configuration)
        {
            IProxyService proxyService = new ProxyService(configuration);

            return proxyService;
        }
    }
}
