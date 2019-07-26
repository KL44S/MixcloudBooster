using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebDriverServices.Mixcloud
{
    public class MixcloudPlayBooster : WebDriverBooster, IPlayBoost
    {
        private static int _sleepMiliseconds = 5000;

        public MixcloudPlayBooster(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        public async Task Play(string trackPath)
        {
            IWebElement button = this.GetPlayButton();
            button.Click();

            await Task.Delay(_sleepMiliseconds);
        }

        private IWebElement GetPlayButton()
        {
            string xPath = "//span[@class='play-button play-button-cloudcast']";
            IWebElement button = this._webDriver.FindElement(By.XPath(xPath));

            return button;
        }
    }
}
