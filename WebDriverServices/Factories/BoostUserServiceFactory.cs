using DataAccessServices;
using Microsoft.Extensions.Configuration;

namespace WebDriverServices.Factories
{
    public class BoostUserServiceFactory
    {
        public static IBoostUserService BuildAndGetBoostUser(IConfiguration configuration)
        {
            IBoostUserService boostUserService = new BoostUserService(configuration);

            return boostUserService;
        }
    }
}
