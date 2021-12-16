using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SharpGaming.Pages;
using SharpGaming.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace SharpGaming.StepsDefinition
{
    [Binding]
    public sealed class RegistrationSteps : DriverHelper
    {

        HomeAndRegistrationPage homeAndRegistrationPage = null;

        [Given(@"user is on home page")]
        public void GivenUserIsOnHomePage()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl("https://www.oddsking.com/");
            homeAndRegistrationPage = new HomeAndRegistrationPage(driver);
        }

        [Given(@"user CTA register button")]
        public void GivenUserCTARegisterButton()
        {
            homeAndRegistrationPage.ClickJoin();
        }

        [When(@"user fill the register form")]
        public void WhenUserFillTheRegisterForm()
        {
            homeAndRegistrationPage.FillEmailField()
            .FillUserNameField();
            homeAndRegistrationPage.FillPasswordField();
            homeAndRegistrationPage.ClickOnCheckBox();
            homeAndRegistrationPage.WaitForContinueOnAccounPage(driver);
            homeAndRegistrationPage.ClickContinueOnAccountForm();
            homeAndRegistrationPage.FillFirstNameField();
            homeAndRegistrationPage.FillLastNameField();
            homeAndRegistrationPage.FillDayOfBirth();
            homeAndRegistrationPage.FillMonthOfBirth();
            homeAndRegistrationPage.FillYearOfBirth();
            homeAndRegistrationPage.ClickContinueOnPersonalForm();
            homeAndRegistrationPage.ClickContinueOnPersonalForm();
            homeAndRegistrationPage.FillTelephoneNumber();
            homeAndRegistrationPage.OpenSecurityQuestionList();
            homeAndRegistrationPage.SelectSecurityQuestion();
            homeAndRegistrationPage.OpenSecurityQuestionList();
            homeAndRegistrationPage.FillSecurityQuestionAnswer();
            homeAndRegistrationPage.RegainFocusOnPage();
            homeAndRegistrationPage.WaitForContinueOnContactPage(driver);
            homeAndRegistrationPage.ClickContinueOnContactForm();
            homeAndRegistrationPage.FillTheAddressForm();
            homeAndRegistrationPage.ClickOnFirstAddressFromTheList();
            homeAndRegistrationPage.RegainFocusOnPage();
            homeAndRegistrationPage.ClickContinueOnAddressForm();
            homeAndRegistrationPage.WaitForContinueOnAddressPage(driver);
            homeAndRegistrationPage.ClickContinueOnAddressForm();
            homeAndRegistrationPage.ClickOnNoMarketingCheckbox1();
            homeAndRegistrationPage.ClickOnNoMarketingCheckbox2();
            homeAndRegistrationPage.ClickOnCookiesConfirmationButton();
            homeAndRegistrationPage.ScrollToElement(driver);
            homeAndRegistrationPage.ClickContinueOnSettingsForm();
        }

        [Then(@"user should be informed that registration was unsuccessful")]
        public void ThenUserShouldBeInformedThatRegistrationWasUnsuccessful()
        {
            var confirmationText = homeAndRegistrationPage.GetTextFromConfirmationBanner();
            Assert.That(confirmationText, Is.EqualTo("Registration Unsuccessful"));
            driver.Close();
        }


    }
}
