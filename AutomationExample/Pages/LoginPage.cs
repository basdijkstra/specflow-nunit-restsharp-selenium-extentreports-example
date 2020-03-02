using OpenQA.Selenium;
using AutomationExample.Helpers;

namespace AutomationExample.Pages
{
    public class LoginPage
    {
        private IWebDriver _driver;
        private SeleniumHelpers selenium;

        private By textfieldUsername = By.Name("username");
        private By textfieldPassword = By.Name("password");
        private By buttonDoLogin = By.XPath("//input[@value='Log In']");

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            selenium = new SeleniumHelpers(_driver);
        }

        public LoginPage Load()
        {
            selenium.NavigateTo("http://parabank.parasoft.com");
            return this;
        }

        public void LoginAs(string username, string password)
        {
            selenium.SendKeys(textfieldUsername, username);
            selenium.SendKeys(textfieldPassword, password);
            selenium.Click(buttonDoLogin);
        }
    }
}
