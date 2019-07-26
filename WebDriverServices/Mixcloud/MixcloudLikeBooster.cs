using System.Threading.Tasks;
using Model;
using OpenQA.Selenium;

namespace WebDriverServices.Mixcloud
{
    public class MixcloudLikeBooster : WebDriverBooster, ILikeBoost
    {
        public BoostUser BoostUser { get; set; }

        public MixcloudLikeBooster(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        public async Task Like(string trackPath)
        {
            MixcloudLogger.LoginIfItIsNecessary(this._webDriver, this.BoostUser);

            await Task.CompletedTask;
        }
    }
}
