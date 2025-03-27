using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AmplifyAutomation.Locators
{
    public class BasePage
    {
        private IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // This will be my locators here

        private IWebElement ConnectWithAnExpertButton => driver.FindElement(By.CssSelector(".a-btn.a-btn--primary.a-btn--small.main_popup_button"));
        //Here I am using by the general css selector

        private IWebElement GreenStartSticker => driver.FindElement(By.ClassName("home-sticker"));
        //This is a little more specific and better practice, this is by class

        //________________________________________________________________________________________________________________________________

        // These are my custom methods

        // Pretty easy stuff right here, just saying "hey click the button"
        public void ClickConnectWithAnExpertButton()
        {
            ConnectWithAnExpertButton.Click();
        }

        // This is also easy and just an Is Visible
        public bool IsGreenStartStickerVisible()
        {
            return GreenStartSticker.Displayed;
        }

    }
}