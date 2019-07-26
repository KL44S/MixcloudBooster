using DataAccessServices;
using Microsoft.Extensions.Configuration;

namespace WebDriverServices.Factories
{
    public class BoostCommentServiceFactory
    {
        public static IBoostCommentService BuildAndGetBoostUser(IConfiguration configuration)
        {
            IBoostCommentService boostCommentService = new BoostCommentService(configuration);

            return boostCommentService;
        }
    }
}
