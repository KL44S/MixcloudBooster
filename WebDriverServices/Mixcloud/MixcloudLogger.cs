using System.Collections.Generic;
using Model;
using OpenQA.Selenium;

namespace WebDriverServices.Mixcloud
{
    public class MixcloudLogger
    {
        public static void LoginIfItIsNecessary(IWebDriver webDriver, BoostUser boostUser)
        {
            try
            {
                string xPath = "//div[@class='user-actions guest']";
                IWebElement section = webDriver.FindElement(By.XPath(xPath));
                IWebElement loginElement = section.FindElements(By.TagName("span"))[0];

                loginElement.Click();

                Login(webDriver, boostUser);
            }
            catch (NoSuchElementException) { }

        }

        private static void Login(IWebDriver webDriver, BoostUser boostUser)
        {

            IWebElement form = webDriver.FindElement(By.TagName("form"));
            IList<IWebElement> inputs = form.FindElements(By.TagName("input"));

            IWebElement userElement = inputs[0];
            IWebElement passElement = inputs[1];

            userElement.SendKeys(boostUser.User);
            passElement.SendKeys(boostUser.Pass);

            IWebElement button = form.FindElement(By.TagName("button"));
            IWebElement span = button.FindElement(By.TagName("span"));
            span.Click();
        }
    }
}
