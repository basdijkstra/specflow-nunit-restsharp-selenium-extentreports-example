

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationExample.Helpers
{
    public class DriverHelper
    {
        public static IWebDriver CreateDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            return driver;
        }
    }
}
