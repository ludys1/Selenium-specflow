using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SharpGaming.Pages;
using SharpGaming.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SharpGaming.StepsDefinitionUI
{
    [Binding]
    class IrishLottoResultSteps : DriverHelper
    {

        IrishLottoHomeAndResultsPage irishLottoHomePage = null;

        [Given(@"user navigates to Irish Lotto page")]
        public void GivenUserNavigatesToIrishLottoPage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.oddsking.com/lotto/irish");
            irishLottoHomePage = new IrishLottoHomeAndResultsPage(driver);
        }

        [When(@"user CTA result button")]
        public void WhenUserCTAResultButton()
        {
            irishLottoHomePage.ClickResultsButton();
        }

        [When(@"filter result for last seven days")]
        public void WhenFilterResultForLastSevenDays()
        {
            irishLottoHomePage.OpenCalenderStartDate();

            if ( DateTime.Now.Day <= 7)
            {
                irishLottoHomePage.ClickOnPreviousMonthButton();
            }
        
            irishLottoHomePage.ClickOnSevenDaysFromTodayDate();
            irishLottoHomePage.ClickOnDoneButton();
            irishLottoHomePage.ClickOnViewFilteredResutsButton();
        }

        [Then(@"user should only see results from seven days ago")]
        public void ThenUserShouldOnlySeeResultsFromSevenDaysAgo()
        {
            Thread.Sleep(2000);
            var searchResultStringList = irishLottoHomePage.FilterResultsList;            

            foreach (var item in searchResultStringList)
            {
                
                var textFromSubstring = item.Text.Substring(0,11);
                var result = Convert.ToDateTime(textFromSubstring);
                Assert.That(irishLottoHomePage.CheckDateRange(result) == true);          
            }
            driver.Close();

        }
    }
}
