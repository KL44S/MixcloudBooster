using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WebDriverServices.Utils
{
    internal class WebDriverProvider
    {
        private static int _milisecondsToWait = 10000;
        private static String _webDriversPath = Path.Combine(Environment.CurrentDirectory, @"..\..\..\..\WebDriverServices\webDrivers");
        public enum Browsers { FIREFOX, EXPLORER, CHROME, EDGE, OPERA };

        public static IWebDriver BuildAndGetWebDriver(Browsers Browser)
        {
            IWebDriver webDriver;

            switch (Browser)
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
                    ChromeOptions crhomeOptions = new ChromeOptions();
                    crhomeOptions.AddArgument("--disable-popup-blocking");
                    crhomeOptions.AddArgument("--mute-audio");

                    webDriver = new ChromeDriver(_webDriversPath, crhomeOptions);
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

            return webDriver;
        }
    }
}
