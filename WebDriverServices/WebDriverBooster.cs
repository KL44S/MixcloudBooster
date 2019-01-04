using OpenQA.Selenium;
using Services;
using System;
using System.Collections.Generic;
using System.Text;
using WebDriverServices.Utils;

namespace WebDriverServices
{
    public class WebDriverBooster : IMixcloudBooster
    {
        private IWebDriver _webDriver;
        private static int _sleepMiliseconds = 5000;

        private IWebElement GetPlayButton()
        {
            String xPath = "//span[@class='play-button play-button-cloudcast']";
            IWebElement button = this._webDriver.FindElement(By.XPath(xPath));

            return button;
        }

        public WebDriverBooster()
        {
            this._webDriver = WebDriverProvider.BuildAndGetWebDriver(WebDriverProvider.Browsers.CHROME);
        }

        public void Boost(String trackPath)
        {
            SeleniumUtils.NavigateTo(this._webDriver, trackPath);

            IWebElement button = this.GetPlayButton();
            button.Click();

            System.Threading.Thread.Sleep(_sleepMiliseconds);
        }

        public void Dispose()
        {
            this._webDriver.Quit();
        }
    }
}
