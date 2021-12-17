using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SharpGaming.Pages;
using SharpGaming.Utils;
using System;
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

        [Given(@"user CTA join button")]
        public void GivenUserCTAJoinButton()
        {
            homeAndRegistrationPage.ClickJoin();
        }

        [When(@"user fill the register account from")]
        public void WhenUserFillTheRegisterAccountFrom()
        {
            homeAndRegistrationPage.FillEmailField();
            homeAndRegistrationPage.FillUserNameField();
            homeAndRegistrationPage.FillPasswordField();
            homeAndRegistrationPage.ClickOnCheckBox();
            homeAndRegistrationPage.WaitForContinueOnAccounPage(driver);
            homeAndRegistrationPage.ClickContinueOnAccountForm();
        }

        [When(@"user fill the personal form")]
        public void WhenUserFillThePersonalForm()
        {
            homeAndRegistrationPage.FillFirstNameField();
            homeAndRegistrationPage.FillLastNameField();
            homeAndRegistrationPage.FillDayOfBirth();
            homeAndRegistrationPage.FillMonthOfBirth();
            homeAndRegistrationPage.FillYearOfBirth();
            homeAndRegistrationPage.ClickContinueOnPersonalForm();
            homeAndRegistrationPage.ClickContinueOnPersonalForm();
        }

        [When(@"user fill the contact form")]
        public void WhenUserFillTheContactForm()
        {
            homeAndRegistrationPage.FillSecurityQuestionAnswer();
            homeAndRegistrationPage.FillTelephoneNumber();
            homeAndRegistrationPage.OpenSecurityQuestionList();
            homeAndRegistrationPage.SelectSecurityQuestion();
            homeAndRegistrationPage.ClickContinueOnContactForm();
        }

        [When(@"user fill the address form")]
        public void WhenUserFillTheAddressForm()
        {
            homeAndRegistrationPage.ClickOnOutsideUkButton();
            homeAndRegistrationPage.FillAddressLine1Field();
            homeAndRegistrationPage.FillCityField();
            homeAndRegistrationPage.ClickOnCookiesConfirmationButton();
            homeAndRegistrationPage.ClickContinueOnAddressForm();
        }

        [When(@"user fill the settings form")]
        public void WhenUserFillTheSettingsForm()
        {         
            homeAndRegistrationPage.ClickOnNoMarketingCheckbox1();
            homeAndRegistrationPage.ClickOnNoMarketingCheckbox2();
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
