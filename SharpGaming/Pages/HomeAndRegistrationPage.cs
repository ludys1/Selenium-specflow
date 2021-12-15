using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SharpGaming.Utils;
using System;
using SeleniumExtras.WaitHelpers;


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

        public IWebElement ContinueButtonAccountPage => WebDriver.FindElement(By.XPath("//button[@data-actionable='RegistrationPage.NavigationButtonsPage1.Continue']"));

        public IWebElement ContinueButtonPersonalPage => WebDriver.FindElement(By.XPath("//button[@data-actionable='RegistrationPage.NavigationButtonsPage2.Continue']"));

        // todo: dupicated code in DOM 
        public IWebElement ContinueButtonContactPage => WebDriver.FindElement(By.XPath("(//button[@data-actionable='RegistrationPage.NavigationButtonsPage3.Continue'])[2]"));

        public IWebElement FirstNameField => WebDriver.FindElement(By.XPath("//input[@id='RegistrationPage.PersonalSection.first_name']"));

        public IWebElement LastNameField => WebDriver.FindElement(By.XPath("//input[@id='RegistrationPage.PersonalSection.last_name']"));

        public IWebElement DateOfBirthFieldDay => WebDriver.FindElement(By.XPath("//input[@data-actionable='RegistrationPage.DateOfBirthInput.day']"));

        public IWebElement DateOfBirthFieldMonth => WebDriver.FindElement(By.XPath("//input[@data-actionable='RegistrationPage.DateOfBirthInput.month']"));

        public IWebElement DateOfBirthFieldYear => WebDriver.FindElement(By.XPath("//input[@data-actionable='RegistrationPage.DateOfBirthInput.year']"));

        public IWebElement PhoneNumberField => WebDriver.FindElement(By.XPath("//input[@id='RegistrationPage.TelephoneNumberInput.telephone.desktop-telephone']"));

        public IWebElement SecurityQuestionList => WebDriver.FindElement(By.XPath("//select[@id='RegistrationPage.Dropdown.desktop-securityQuestion']"));

        public IWebElement MothersMaidenOptionFromSecurityQuestionList => WebDriver.FindElement(By.XPath("//select[@id='RegistrationPage.Dropdown.desktop-securityQuestion']/option[2]"));

        public IWebElement SecurityQuestionAnswerField => WebDriver.FindElement(By.XPath("//input[@id='RegistrationPage.ContactSection.desktop_security_answer']"));

        public IWebElement RegainFocus => WebDriver.FindElement(By.XPath("//div[@id='page-wrapper']"));


        public void ClickJoin() => JoinButton.Click();
        public void ClickOnCheckBox() => CheckBoxTandC.Click();
        public void ClickContinueOnAccountForm() => ContinueButtonAccountPage.Click();
        public void ClickContinueOnPersonalForm() => ContinueButtonPersonalPage.Click();
        public void ClickContinueOnContactForm() => ContinueButtonContactPage.Click();
        public void FillEmailField() => EmailField.SendKeys(FakerData.Email);
        public void FillUserNameField() => UserNameField.SendKeys(FakerData.FirsName + "23");
        public string FillPasswordField() {
            var password = FakerData.Pass + '1';
            PasswordField.SendKeys(password); 
                return password;
        }
        public void FillFirstNameField() => FirstNameField.SendKeys(FakerData.FirsName);
        public void FillLastNameField() => LastNameField.SendKeys(FakerData.LastName);
        public void FillDayOfBirth() => DateOfBirthFieldDay.SendKeys(FakerData.Day);
        public void FillMonthOfBirth() => DateOfBirthFieldMonth.SendKeys(FakerData.Month);
        public void FillYearOfBirth() => DateOfBirthFieldYear.SendKeys(FakerData.Year);
        public void FillTelephoneNumber() => PhoneNumberField.SendKeys(FakerData.PhoneNumber);
        public void OpenSecurityQuestionList() => SecurityQuestionList.Click();
        public void SelectSecurityQuestion() => MothersMaidenOptionFromSecurityQuestionList.Click();
        public void FillSecurityQuestionAnswer() => SecurityQuestionAnswerField.SendKeys(FakerData.Text);
        public void RegainFocusOnPage() => RegainFocus.Click();

        public void WaitForContinue(IWebDriver driver, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.TextToBePresentInElementValue(WebDriver.FindElement(By.XPath("//input[@id='RegistrationPage.AccountSection.password']")), "text"));
        }

        


    }
}
