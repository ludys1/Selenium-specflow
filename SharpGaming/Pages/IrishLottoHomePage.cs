using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharpGaming.Pages
{
    class IrishLottoHomePage
    {
        public IWebDriver WebDriver { get; }
        public IrishLottoHomePage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }
}
