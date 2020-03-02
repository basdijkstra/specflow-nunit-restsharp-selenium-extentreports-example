using OpenQA.Selenium;
using AutomationExample.Helpers;

namespace AutomationExample.Pages
{
    public class RequestLoanPage
    {
        private IWebDriver _driver;
        private SeleniumHelpers selenium;

        private By textfieldLoanAmount = By.Id("amount");
        private By textfieldDownPayment = By.Id("downPayment");
        private By dropdownFromAccountId = By.Id("fromAccountId");
        private By buttonApplyForLoan = By.XPath("//input[@value='Apply Now']");

        public RequestLoanPage(IWebDriver driver)
        {
            _driver = driver;
            selenium = new SeleniumHelpers(_driver);
        }

        public void SubmitLoanRequestForAmount(string loanAmount, string downPayment, string fromAccountId)
        {
            selenium.SendKeys(textfieldLoanAmount, loanAmount);
            selenium.SendKeys(textfieldDownPayment, downPayment);
            selenium.Select(dropdownFromAccountId, fromAccountId);
            selenium.Click(buttonApplyForLoan);
        }

    }
}
