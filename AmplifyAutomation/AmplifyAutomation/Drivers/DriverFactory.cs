using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace AmplifyAutomation.Drivers
{

    public class DriverFactory
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver()
        {
            if (driver == null)
            {
                var options = new ChromeOptions();
                driver = new ChromeDriver(options);
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            }
            return driver;
        }

        public static void QuitDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver = null;
            }
        }
    }
}
