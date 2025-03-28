using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using AmplifyAutomation.Drivers;

namespace AmplifyAutomation.Hooks
{
    internal class BreakDownHooks
    {
        [Binding]
        public sealed class Hooks
        {
            [AfterScenario]
            public void TearDown()
            {
                DriverFactory.QuitDriver(); 
            }
        }
    }
}
