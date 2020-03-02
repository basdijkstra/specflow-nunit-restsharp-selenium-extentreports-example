using AutomationExample.Helpers;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationExample.StepDefinitions
{
    [Binding]
    public class SetupTeardownSteps
    {
        [BeforeFeature]
        public static void CreateReport(FeatureContext context)
        {
            ExtentReports extent = new ExtentReports();
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter($"C:\\Git\\{context.FeatureInfo.Title}\\report.html");
            extent.AttachReporter(htmlReporter);
            context.Set(extent);
        }

        [BeforeScenario]
        public void StartReporting(FeatureContext context, ScenarioContext scContext)
        {
            ExtentTest test = context.Get<ExtentReports>().CreateTest(scContext.ScenarioInfo.Title);
            scContext.Set(test);
        }

        [BeforeScenario]
        [Scope(Tag = "browser")]
        public void StartBrowser(ScenarioContext context)
        {
            IWebDriver driver = DriverHelper.CreateDriver();
            context.Set(driver);
        }

        [AfterScenario]
        [Scope(Tag = "browser")]
        public void StopBrowser(ScenarioContext context)
        {
            IWebDriver driver = context.Get<IWebDriver>();
            driver.Quit();
        }

        [AfterScenario]
        public void WriteTestResult(TestContext testContext, ScenarioContext scenarioContext)
        {
            switch (testContext.Result.Outcome.Status) {
                case TestStatus.Passed:
                    scenarioContext.Get<ExtentTest>().Pass("Passed the test");
                    break;
                case TestStatus.Failed:
                    scenarioContext.Get<ExtentTest>().Fail("Failed the test");
                    break;
                default:
                    scenarioContext.Get<ExtentTest>().Warning("Could not determine test result");
                    break;
            }
        }

        [AfterFeature]
        public static void StopReporting(FeatureContext context)
        {
            context.Get<ExtentReports>().Flush();
        }
    }
}
