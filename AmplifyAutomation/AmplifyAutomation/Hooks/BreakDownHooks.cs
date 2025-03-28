using System;
using System.Reflection;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AmplifyAutomation.Drivers;
using AmplifyAutomation.Utils;


namespace AmplifyAutomation.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly ScenarioContext _scenarioContext;

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [AfterScenario]
        public void TearDown()
        {
            DriverFactory.QuitDriver();
        }


        // Okay now I need to build out actual test rail reporting
        [AfterScenario]
        public void ReportToTestRail()
        {
            var stepDefinitionType = typeof(AmplifyAutomation.StepDefinitions.BasePageSteps);
            var methods = stepDefinitionType.GetMethods();

            foreach (var method in methods)
            {
                var attr = method.GetCustomAttribute<TestRailCaseAttribute>();
                if (attr != null)
                {
                    var caseId = attr.CaseId;
                    var statusId = _scenarioContext.TestError == null ? 1 : 5;
                    var comment = _scenarioContext.TestError?.Message ?? "Test passed successfully.";

                    TestRailHelper.AddResultForTestCase(caseId, statusId, comment);
                    break;
                }
            }
        }
    }
}
