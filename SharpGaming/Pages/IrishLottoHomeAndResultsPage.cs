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
        public IWebElement DoneButton => WebDriver.FindElement(By.XPath("//*[@data-actionable='Form.Datepicker.Continue']"));

        public IWebElement SevenDaysBeforeToday(int day) => WebDriver.FindElement(By.XPath($"//*[contains(@class,'Form.Datepicker.DayButton-{day}') and not(@disabled)]"));
        public IWebElement PreviousMonthButton => WebDriver.FindElement(By.XPath("//*[@data-actionable='Form.Datepicker.CalendarPreviousMonthButton']"));
        public IWebElement FilterResult => WebDriver.FindElement(By.XPath("//*[contains(@data-actionable,'Lotto.DrawTile-IRISHLOTTERY')]"));

        public List<IWebElement> FilterResults => (List<IWebElement>)WebDriver.FindElement(By.XPath("//*[contains(@data-actionable,'Lotto.DrawTile-IRISHLOTTERY')]"));


        public void ClickResultsButton() => ResultsButton.Click();
        public void OpenCalenderStartDate() => StartDateSelect.Click();
        public void ClickOnViewFilteredResutsButton() => ViewFilteredResults.Click();
        public void ClickOnDoneButton() => DoneButton.Click();
        public void ClickOnSevenDaysFromTodayDate() => SevenDaysBeforeToday(ReturnDaysEarlierFromToday(7)).Click();

        public int ReturnDaysEarlierFromToday(int days)
        {
           return DateTime.Today.AddDays(-days).Day;
        }

        public void ClickOnPreviousMonthButton() => PreviousMonthButton.Click();
        public string GetDatesFromFilterResults() => FilterResult.Text;

        public bool CheckDateRange(DateTime date)
        {
            DateTime today = DateTime.Today;
            DateTime dateInPast = today.AddDays(-7);

            if (dateInPast <= date && date <= today)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
