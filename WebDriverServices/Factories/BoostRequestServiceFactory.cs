using DataAccessServices;
using Microsoft.Extensions.Configuration;

namespace WebDriverServices.Factories
{
    public class BoostRequestServiceFactory
    {
        public static IBoostRequestService BuildAndGetBoostUser(IConfiguration configuration)
        {
            IBoostRequestService boostRequestService = new BoostRequestService(configuration);

            return boostRequestService;
        }
    }
}
