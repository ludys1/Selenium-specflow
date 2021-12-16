using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGaming.Pages
{
    class IrishLottoHomeAndResultsPage
    {
        public IWebDriver WebDriver { get; }
        public IrishLottoHomeAndResultsPage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebElement ResultsButton => WebDriver.FindElement(By.XPath("//*[@data-actionable='Lotto.SelectLottoBanner.Results']"));
        public IWebElement StartDateSelect => WebDriver.FindElement(By.XPath("//*[@data-actionable='Lotto.ResultsDateFilter.SetDateFrom']"));
        public IWebElement ViewFilteredResults => WebDriver.FindElement(By.XPath("//*[@data-actionable='LottoApp.ResultsPage.DateFilter.submit']"));
        public IWebElement SeventhDecemberButton => WebDriver.FindElement(By.XPath("//*[@class='react-calendar__tile react-calendar__month-view__days__day Form.Datepicker.DayButton-7 _g56jkt']"));
        public IWebElement DoneButton => WebDriver.FindElement(By.XPath("//*[@data-actionable='Form.Datepicker.Continue']"));

        //*[contains(@data-actionable,'Lotto.DrawTile-IRISHLOTTERY')]

        //*[contains(@class,'Form.Datepicker.DayButton-7') and not(@disabled)]

        public void ClickResultsButton() => ResultsButton.Click();
        public void OpenCalenderStartDate() => StartDateSelect.Click();
        public void ClickOnViewFilteredResutsButton() => ViewFilteredResults.Click();
        public void SetSeventhOfDecember() => SeventhDecemberButton.Click();
        public void ClickOnDoneButton() => DoneButton.Click();

        public int ReturnDaysEarlierFromToday(int days)
        {
           return DateTime.Today.AddDays(-days).Day;
        }
        
    }
}
