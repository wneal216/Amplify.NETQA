using TechTalk.SpecFlow;
using OpenQA.Selenium;
using NUnit.Framework;
using AmplifyAutomation.Locators;
using AmplifyAutomation.Drivers;
using AmplifyAutomation.Utils;

namespace AmplifyAutomation.StepDefinitions
{
	[Binding]

	public class BasePageSteps
	{
		private readonly BasePage basePage;
		private readonly IWebDriver driver;

		public BasePageSteps()
		{
			driver = DriverFactory.GetDriver();
			//remember I set my driver up earlier to save us the hassle
			basePage = new BasePage(driver);
		}

		[Given(@"the user is on the landing page")]
		public void GivenTheUserIsOnTheLandingPage()
		{
			driver.Navigate().GoToUrl(Config.BaseUrl);
        }

		//____________________________________________________________________________________________________________

		[When(@"the user clicks the Connect With an Expert button")]
		public void WhenTheUserClicksTheConnectWithAnExpertButton()
		{
			basePage.ClickConnectWithAnExpertButton();
		}

		[When(@"the user clicks the Shop Button")]
		public void WhenTheUserClicksTheShopButton()
		{
			basePage.ClickShopButton();	
		}

		//______________________________________________________________________________________________________________

		[Then(@"the green start sticker should be visible")]
		public void ThenTheGreenStartStickerShouldBeVisible()
		{
			Assert.IsTrue(basePage.IsGreenStartStickerVisible(), "Green start sticker was not visible.");
		}

        // this is an example of how I would attach the TC's for test rail
        [TestRailCase(2169)]
        [Then(@"the shop button is visible")]
		public void ThenTheShopButtonIsVisible()
		{
			Assert.IsTrue(basePage.IsShopButtonVisible(), "Shop Button was not visible.");
		}
	}
}