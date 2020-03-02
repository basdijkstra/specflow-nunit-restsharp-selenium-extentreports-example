using AutomationExample.Helpers;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationExample.StepDefinitions
{
    [Binding]
    public class SetupTeardownSteps
    {
        [BeforeScenario]
        public void StartBrowser(ScenarioContext context)
        {
            IWebDriver driver = DriverHelper.CreateDriver();
            context.Set(driver);
        }

        [AfterScenario]
        public void StopBrowser(ScenarioContext context)
        {
            IWebDriver driver = context.Get<IWebDriver>();
            driver.Quit();
        }
    }
}
