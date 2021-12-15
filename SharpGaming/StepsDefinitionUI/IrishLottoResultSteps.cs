using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SharpGaming.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SharpGaming.StepsDefinitionUI
{
    [Binding]
    class IrishLottoResultSteps
    {
        IWebDriver driver;

        IrishLottoHomePage irishLottoHomePage = null;

        [Given(@"user navigates to Irish Lotto page")]
        public void GivenUserNavigatesToIrishLottoPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.oddsking.com/lotto/irish");
            irishLottoHomePage = new IrishLottoHomePage(driver);
        }

        [When(@"user CTA result button")]
        public void WhenUserCTAResultButton()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"filter result for last seven days")]
        public void WhenFilterResultForLastSevenDays()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"user should only see results from seven days ago")]
        public void ThenUserShouldOnlySeeResultsFromSevenDaysAgo()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
