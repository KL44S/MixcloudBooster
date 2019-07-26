using System;
using System.Collections.Generic;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;

namespace WebDriverServices.Utils
{
    internal class WebDriverProvider
    {
        private static int _milisecondsToWait = 10000;
        private static string _webDriversPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\WebDriverServices\webDrivers");
        public enum Browsers { FIREFOX, EXPLORER, CHROME, EDGE, OPERA };

        public static IWebDriver BuildAndGetWebDriver(Browsers browser, IList<string> options)
        {
            IWebDriver webDriver;

            switch (browser)
            {
                case Browsers.EXPLORER:
                    webDriver = new InternetExplorerDriver(_webDriversPath);
                    break;

                case Browsers.FIREFOX:
                    FirefoxOptions FirefoxOptions = new FirefoxOptions();
                    FirefoxDriverService FirefoxDriverService = FirefoxDriverService.CreateDefaultService(_webDriversPath);
                    FirefoxOptions.BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe";
                    TimeSpan TimeSpan = new TimeSpan(1, 0, 0);

                    webDriver = new FirefoxDriver(FirefoxDriverService, FirefoxOptions, TimeSpan);

                    break;

                case Browsers.CHROME:

                    if (options != null)
                    {
                        ChromeOptions crhomeOptions = new ChromeOptions();

                        foreach (string option in options)
                        {
                            crhomeOptions.AddArgument(option);
                        }

                        webDriver = new ChromeDriver(_webDriversPath, crhomeOptions);
                    }
                    else
                    {
                        webDriver = new ChromeDriver(_webDriversPath);
                    }

                    break;

                case Browsers.EDGE:
                    webDriver = new EdgeDriver(_webDriversPath);
                    break;

                case Browsers.OPERA:
                    OperaDriverService OperaDriverService = OperaDriverService.CreateDefaultService(_webDriversPath);
                    OperaOptions OperaOptions = new OperaOptions();
                    OperaOptions.BinaryLocation = @"C:\Program Files\Opera\54.0.2952.71\opera.exe";

                    webDriver = new OperaDriver(OperaDriverService, OperaOptions);

                    break;

                default:
                    throw new Exception();
            }

            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(_milisecondsToWait);
            webDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMilliseconds(int.MaxValue);

            return webDriver;
        }

        public static IWebDriver BuildAndGetWebDriver(Browsers browser)
        {
            IList<string> chromeOptions = new List<string>();
            chromeOptions.Add("--disable-popup-blocking");
            chromeOptions.Add("--mute-audio");
            chromeOptions.Add("no-sandbox");

            IWebDriver webDriver = BuildAndGetWebDriver(browser, chromeOptions);
            
            return webDriver;
        }

        public static bool TestProxy(Browsers browser, string proxyPath)
        {
            bool isTheProxyWorking = true;

            IList<string> options = new List<string>();
            options.Add("--proxy-server=" + proxyPath);
            options.Add("no-sandbox");

            string testUrl = @"http://www.google.com.ar/";

            IWebDriver webDriver = WebDriverProvider.BuildAndGetWebDriver(browser, options);
            SeleniumUtils.GoToUrl(webDriver, testUrl);

            try
            {
                string xPath = "//body[@id='t']";
                IWebElement noConnectionBody = webDriver.FindElement(By.XPath(xPath));

                isTheProxyWorking = false;
            }
            catch (NoSuchElementException) {}

            webDriver.Quit();

            return isTheProxyWorking;
        }
    }
}
