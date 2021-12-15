using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SharpGaming.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SharpGaming.StepsDefinition
{
    [Binding]
    public sealed class RegistrationSteps
    {
        IWebDriver driver;

        HomeAndRegistrationPage homeAndRegistrationPage = null;

        [Given(@"user is on home page")]
        public void GivenUserIsOnHomePage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.oddsking.com/");
            homeAndRegistrationPage = new HomeAndRegistrationPage(driver);

            //DefaultWait<IWebDriver> fluentWait = new DefaultWait<IWebDriver>(driver);
            //fluentWait.Timeout = TimeSpan.FromSeconds(5);
            //fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
            ///* Ignore the exception - NoSuchElementException that indicates that the element is not present */
            //fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            //fluentWait.Message = "Element to be searched not found";

        }

        [Given(@"user CTA register button")]
        public void GivenUserCTARegisterButton()
        {
            homeAndRegistrationPage.ClickJoin();
        }

        [When(@"user fill the register form")]
        public void WhenUserFillTheRegisterForm()
        {

            homeAndRegistrationPage.FillEmailField();
            homeAndRegistrationPage.FillUserNameField();
            var password = homeAndRegistrationPage.FillPasswordField();
            homeAndRegistrationPage.ClickOnCheckBox();
            //Thread.Sleep(2000);
            homeAndRegistrationPage.WaitForContinue(driver, password);
            Thread.Sleep(2000);
            homeAndRegistrationPage.ClickContinueOnAccountForm();
            homeAndRegistrationPage.FillFirstNameField();
            homeAndRegistrationPage.FillLastNameField();
            homeAndRegistrationPage.FillDayOfBirth();
            homeAndRegistrationPage.FillMonthOfBirth();
            homeAndRegistrationPage.FillYearOfBirth();
            //Thread.Sleep(2000);
            homeAndRegistrationPage.ClickContinueOnPersonalForm();
            homeAndRegistrationPage.ClickContinueOnPersonalForm();
            homeAndRegistrationPage.FillTelephoneNumber();
            homeAndRegistrationPage.OpenSecurityQuestionList();
            homeAndRegistrationPage.SelectSecurityQuestion();
            homeAndRegistrationPage.OpenSecurityQuestionList();
            //Thread.Sleep(2000);
            homeAndRegistrationPage.FillSecurityQuestionAnswer();
            //Thread.Sleep(2000);
            homeAndRegistrationPage.RegainFocusOnPage();
            //Thread.Sleep(2000);
            homeAndRegistrationPage.ClickContinueOnContactForm();
            //Thread.Sleep(2000);
            homeAndRegistrationPage.ClickContinueOnContactForm();

        }

        [Then(@"he should be informed about wrong location")]
        public void ThenHeShouldBeInformedAboutWrongLocation()
        {
           // Assert.That(true = true);
        }

    }
}
