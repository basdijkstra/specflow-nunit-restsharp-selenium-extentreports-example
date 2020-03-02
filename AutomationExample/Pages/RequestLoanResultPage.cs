using OpenQA.Selenium;
using AutomationExample.Helpers;

namespace AutomationExample.Pages
{
    public class RequestLoanResultPage
    {
        private IWebDriver _driver;
        private SeleniumHelpers selenium;

        private By textfieldLoanRequestResult = By.Id("loanStatus");

        public RequestLoanResultPage(IWebDriver driver)
        {
            _driver = driver;
            selenium = new SeleniumHelpers(_driver);
        }

        public string GetLoanRequestResult()
        {
            return selenium.GetElementText(textfieldLoanRequestResult);
        }
    }
}
