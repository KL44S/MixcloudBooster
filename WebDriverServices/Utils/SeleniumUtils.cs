using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebDriverServices.Utils
{
    public class SeleniumUtils
    {
        private static int _secondsToWait = 10;

        public static IWebElement FindElement(IWebDriver webDriver, By by)
        {
            WebDriverWait Wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(_secondsToWait));
            IWebElement DynamicElement = Wait.Until<IWebElement>(d => d.FindElement(by));

            return DynamicElement;
        }

        public static IEnumerable<IWebElement> FindElements(IWebDriver webDriver, By by)
        {
            WebDriverWait Wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(_secondsToWait));
            IEnumerable<IWebElement> DynamicElements = Wait.Until<IEnumerable<IWebElement>>(d => d.FindElements(by));

            return DynamicElements;
        }

        public static void NavigateTo(IWebDriver webDriver, String url)
        {
            try
            {
                webDriver.Navigate().GoToUrl(url);

                IAlert alert = webDriver.SwitchTo().Alert();
                alert.Accept();
            }
            catch (NoAlertPresentException) { }
        }
    }
}
