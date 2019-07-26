using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessServices;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using WebDriverServices.Factories;
using WebDriverServices.Utils;

namespace WebDriverServices.Soundcloud
{
    public class SoundcloudPlayBooster : WebDriverBooster, IPlayBoost
    {
        private static int SleepMilliseconds = 5000;
        private static WebDriverProvider.Browsers Browser = WebDriverProvider.Browsers.CHROME;

        private IList<Model.Proxy> _proxies;
        private Task _loadProxiesTask;
        private readonly Random _random;

        public SoundcloudPlayBooster(IWebDriver webDriver, IConfiguration configuration)
        {
            this._webDriver = webDriver;
            this._loadProxiesTask = this.LoadProxies(configuration);
            this._random = new Random();
        }

        public async Task Play(string trackPath)
        {
            await this._loadProxiesTask;

            Model.Proxy newProxy = this.GetNewProxy();
            IList<string> options = this.GetOptions(newProxy.FullPath);

            this.InitWebDriver(options);
            this.DoPlay(trackPath);

            await Task.Delay(SleepMilliseconds);

            this._webDriver.Quit();
        }

        private IList<string> GetOptions(string proxy)
        {
            IList<string> options = new List<string>();
            options.Add("--disable-popup-blocking");
            options.Add("--mute-audio");
            options.Add("no-sandbox");
            options.Add("--proxy-server=" + proxy);

            return options;
        }

        private void InitWebDriver(IList<string> options)
        {
            if (this._webDriver != null)
            {
                this._webDriver.Quit();
            }

            this._webDriver = WebDriverProvider.BuildAndGetWebDriver(Browser, options);
        }

        private async Task LoadProxies(IConfiguration configuration)
        {
            IProxyService proxyService = ProxyServiceFactory.BuildAndGetBoostUser(configuration);
            this._proxies = await proxyService.GetProxies();
        }

        private Model.Proxy GetNewProxy()
        {
            bool isTheProxyWorking = false;
            Model.Proxy proxy = null;

            while (!isTheProxyWorking)
            {
                int proxyIndex = this._random.Next(this._proxies.Count);

                proxy = this._proxies.ElementAt(proxyIndex);
                this._proxies.RemoveAt(proxyIndex);

                isTheProxyWorking = WebDriverProvider.TestProxy(Browser, proxy.FullPath);
            }

            return proxy;
        }

        private void DoPlay(string trackPath)
        {
            string playXPath = "//a[@class='sc-button-play playButton sc-button m-stretch']";

            SeleniumUtils.GoToUrl(this._webDriver, trackPath);

            try
            {
                IWebElement playButton = this._webDriver.FindElement(By.XPath(playXPath));
                playButton.Click();
            }
            catch (NoSuchElementException) { }
        }
    }
}
