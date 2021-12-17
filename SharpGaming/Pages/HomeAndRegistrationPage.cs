using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SharpGaming.Utils;
using System;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Interactions;

namespace SharpGaming.Pages
{
    public class HomeAndRegistrationPage
    {
        public IWebDriver WebDriver { get; }
        public HomeAndRegistrationPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement JoinButton => WebDriver.FindElement(By.XPath("//*[@href='/registration']"));
        public IWebElement EmailField => WebDriver.FindElement(By.XPath("//input[@id='RegistrationPage.AccountSection.email']"));
        public IWebElement UserNameField => WebDriver.FindElement(By.XPath("//input[@id='RegistrationPage.AccountSection.username']"));
        public IWebElement PasswordField => WebDriver.FindElement(By.XPath("//input[@id='RegistrationPage.AccountSection.password']"));
        public IWebElement CheckBoxTandC => WebDriver.FindElement(By.XPath("//*[@data-actionable='RegistrationPage.TermsAndConditions.agree_terms']"));
        public IWebElement ContinueButtOnAccountPage => WebDriver.FindElement(By.XPath("//button[@data-actionable='RegistrationPage.NavigationButtonsPage1.Continue']"));
        public IWebElement ContinueButtOnPersonalPage => WebDriver.FindElement(By.XPath("//button[@data-actionable='RegistrationPage.NavigationButtonsPage2.Continue']"));
        // dupicated code in DOM should be fixed by a developer
        public IWebElement ContinueButtOnContactPage => WebDriver.FindElement(By.XPath("(//button[@data-actionable='RegistrationPage.NavigationButtonsPage3.Continue'])[2]"));
        public IWebElement ContinueButtOnAddressPage => WebDriver.FindElement(By.XPath("//button[@data-actionable='RegistrationPage.NavigationButtonsPage4.Continue']"));
        public IWebElement RegisterButtOnSettingsPage => WebDriver.FindElement(By.XPath("//button[@data-actionable='RegistrationPage.NavigationButtonsPage5.Register']"));
        public IWebElement FirstNameField => WebDriver.FindElement(By.XPath("//input[@id='RegistrationPage.PersonalSection.first_name']"));
        public IWebElement LastNameField => WebDriver.FindElement(By.XPath("//input[@id='RegistrationPage.PersonalSection.last_name']"));
        public IWebElement DateOfBirthFieldDay => WebDriver.FindElement(By.XPath("//input[@data-actionable='RegistrationPage.DateOfBirthInput.day']"));
        public IWebElement DateOfBirthFieldMonth => WebDriver.FindElement(By.XPath("//input[@data-actionable='RegistrationPage.DateOfBirthInput.month']"));
        public IWebElement DateOfBirthFieldYear => WebDriver.FindElement(By.XPath("//input[@data-actionable='RegistrationPage.DateOfBirthInput.year']"));
        public IWebElement PhoneNumberField => WebDriver.FindElement(By.XPath("//input[@id='RegistrationPage.TelephoneNumberInput.telephone.desktop-telephone']"));
        public IWebElement SecurityQuestionList => WebDriver.FindElement(By.XPath("//select[@id='RegistrationPage.Dropdown.desktop-securityQuestion']"));
        public IWebElement MothersMaidenOptionFromSecurityQuestionList => WebDriver.FindElement(By.XPath("//select[@id='RegistrationPage.Dropdown.desktop-securityQuestion']/option[2]"));
        public IWebElement SecurityQuestionAnswerField => WebDriver.FindElement(By.XPath("//input[@id='RegistrationPage.ContactSection.desktop_security_answer']"));
        public IWebElement RegainFocus => WebDriver.FindElement(By.XPath("//*[@data-actionable='RegistrationPage.RegisterHeader.desktop.title']"));
        public IWebElement AddressSearchField => WebDriver.FindElement(By.XPath("//input[@data-actionable='RegistrationPage.search_address']"));
        public IWebElement AddressSearchFieldFirstFromList => WebDriver.FindElement(By.XPath("//*[@class='pcaitem pcafirstitem pcaselected']"));
        public IWebElement NoMarketingCheckbox1 => WebDriver.FindElement(By.XPath("//*[@id='firstParty-No Marketing-checkbox']/.."));
        public IWebElement NoMarketingCheckbox2 => WebDriver.FindElement(By.XPath("//*[@id='thirdParty-No Marketing-checkbox']/.."));
        public IWebElement CookiesContinueButton => WebDriver.FindElement(By.XPath("//button[@data-actionable='Header.CookieBanner.accept_cookies']"));
        public IWebElement TextFromConfirmationBanner => WebDriver.FindElement(By.XPath("//*[text() = 'Registration Unsuccessful']"));


        public void ClickJoin() => JoinButton.Click();
        public void ClickOnCheckBox() => CheckBoxTandC.Click();
        public void ClickContinueOnAccountForm() => ContinueButtOnAccountPage.Click();
        public void ClickContinueOnPersonalForm() => ContinueButtOnPersonalPage.Click();
        public void ClickContinueOnContactForm() => ContinueButtOnContactPage.Click();
        public void ClickContinueOnAddressForm() => ContinueButtOnAddressPage.Click();
        public void ClickContinueOnSettingsForm() => RegisterButtOnSettingsPage.Click();
        public HomeAndRegistrationPage FillEmailField()
        {
            EmailField.SendKeys(FakerData.Email);
            return this;
        }
        public void FillUserNameField() => UserNameField.SendKeys(FakerData.FirsName + "23");
        public void FillPasswordField() => PasswordField.SendKeys(FakerData.Pass + '1');
        public void FillFirstNameField() => FirstNameField.SendKeys(FakerData.FirsName);
        public void FillLastNameField() => LastNameField.SendKeys(FakerData.LastName);
        public void FillDayOfBirth() => DateOfBirthFieldDay.SendKeys(FakerData.Day);
        public void FillMonthOfBirth() => DateOfBirthFieldMonth.SendKeys(FakerData.Month);
        public void FillYearOfBirth() => DateOfBirthFieldYear.SendKeys(FakerData.Year);
        public void FillTelephoneNumber() => PhoneNumberField.SendKeys(FakerData.PhoneNumber);
        public void OpenSecurityQuestionList() => SecurityQuestionList.Click();
        public void SelectSecurityQuestion() => MothersMaidenOptionFromSecurityQuestionList.Click();
        public void FillSecurityQuestionAnswer() => SecurityQuestionAnswerField.SendKeys(FakerData.LastName);
        public void RegainFocusOnPage() => RegainFocus.Click();
        public void FillTheAddressForm() => AddressSearchField.SendKeys("Prusa");
        public void ClickOnFirstAddressFromTheList() => AddressSearchFieldFirstFromList.Click();
        public void ClickOnNoMarketingCheckbox1() => NoMarketingCheckbox1.Click();
        public void ClickOnNoMarketingCheckbox2() => NoMarketingCheckbox2.Click();
        public void ClickOnCookiesConfirmationButton() => CookiesContinueButton.Click();

        public void WaitForContinueOnAccounPage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-actionable='RegistrationPage.AccountSection.email-isSuccess']")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-actionable='RegistrationPage.AccountSection.username-isSuccess']")));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-actionable='RegistrationPage.AccountSection.password-isSuccess']")));
        }

        public void WaitForContinueOnContactPage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-actionable='RegistrationPage.ContactSection.desktop_security_answer-isSuccess']")));
        }

        public void WaitForContinueOnAddressPage(IWebDriver driver)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[@data-actionable='RegistrationPage.NavigationButtonsPage4.Continue']")));
        }

        public void ScrollToElement(IWebDriver driver)
        {
            var element = driver.FindElement(By.XPath("//button[@data-actionable='RegistrationPage.NavigationButtonsPage5.Register']"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public string GetTextFromConfirmationBanner()
        {
            return TextFromConfirmationBanner.Text;
        }
    }
}
