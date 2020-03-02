using System;
using OpenQA.Selenium;
using WebDriverWait = OpenQA.Selenium.Support.UI.WebDriverWait;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace AutomationExample.Helpers
{
    public class SeleniumHelpers
    {
        private IWebDriver _driver;

        public SeleniumHelpers(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateTo(String url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public void SendKeys(By by, string valueToType)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Clear();
                myElement.SendKeys(valueToType);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in SendKeys(): element located by {by.ToString()} not visible and enabled within 10 seconds.");
            }
        }

        public void Click(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                myElement.Click();
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in Click(): element located by {by.ToString()} not visible and enabled within 10 seconds.");
            }
        }

        public void Select(By by, string valueToSelect)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                SelectElement dropdown = new SelectElement(_driver.FindElement(by));
                dropdown.SelectByText(valueToSelect);
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in Click(): element located by {by.ToString()} not visible and enabled within 10 seconds.");
            }
        }

        public bool CheckElementIsVisible(By by)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            return wait.Until(driver => {
                try
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return tempElement.Displayed;
                }
                catch
                {
                    return false;
                }
            });
        }


        public string GetElementText(By by)
        {
            string returnValue = "";

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));

            try
            {
                IWebElement myElement = wait.Until<IWebElement>(driver =>
                {
                    IWebElement tempElement = _driver.FindElement(by);
                    return (tempElement.Displayed && tempElement.Enabled) ? tempElement : null;
                }
                );
                returnValue = myElement.Text;
            }
            catch (WebDriverTimeoutException)
            {
                Assert.Fail($"Exception in GetElementText(): element located by {by.ToString()} not visible and enabled within 10 seconds.");
            }

            return returnValue;
        }
    }
}
