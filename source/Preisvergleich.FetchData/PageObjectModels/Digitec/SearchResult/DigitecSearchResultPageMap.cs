using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Preisvergleich.FetchData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels.Digitec.SearchResult
{
    internal static class DigitecSearchResultPageMap
    {
        public static IWebElement GetPrice =>
            WebUiDriver.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div/article[1]/div[4]/span")));
    }
}
