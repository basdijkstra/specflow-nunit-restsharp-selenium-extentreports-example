using AutomationExample.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationExample.StepDefinitions
{
    [Binding]
    public class LoanRequestSteps
    {
        private ScenarioContext _context;
        private IWebDriver driver;
        
        public LoanRequestSteps(ScenarioContext context)
        {
            _context = context;
            driver = _context.Get<IWebDriver>();
        }

        [Given(@"(.*) wants to apply for a loan")]
        public void GivenWantsToApplyForALoan(string firstName)
        {
            new LoginPage(driver)
                .Load()
                .LoginAs("john", "demo");

            new AccountsOverviewPage(driver)
                .SelectMenuItem("Request Loan");
        }
        
        [When(@"s?he submits a request for a (.*) dollar loan with a (.*) dollar down payment")]
        public void WhenHeSubmitsARequestForADollarLoanWithADollarDownPayment(string loanAmount, string downPayment)
        {
            new RequestLoanPage(driver)
                .SubmitLoanRequestForAmount(loanAmount, downPayment, "54321");
        }
        
        [Then(@"he sees that his loan request is denied")]
        public void ThenHeSeesThatHisLoanRequestIsDenied()
        {
            Assert.That(new RequestLoanResultPage(driver).GetLoanRequestResult(), Is.EqualTo("Denied"));
        }
    }
}
