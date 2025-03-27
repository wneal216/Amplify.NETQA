using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace AmplifyAutomation.Utils
{
    public static class WaitHelper
    {
        //this is just here to deal with any time out errors
        //or slow loading times, we mentioned before that
        //parallel testing can run into issues with waits


        public static void WaitForElementVisible(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitForElementClickable(IWebDriver driver, By locator, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitForPageToLoad(IWebDriver driver, int timeoutInSeconds = 10)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }
}
