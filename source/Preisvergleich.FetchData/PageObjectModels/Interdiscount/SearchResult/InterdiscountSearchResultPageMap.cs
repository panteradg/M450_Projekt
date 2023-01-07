using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Preisvergleich.FetchData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels.Interdiscount.SearchResult
{
    internal static class InterdiscountSearchResultPageMap
    {
        public static IWebElement GetPrice =>
            WebUiDriver.wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[@data-cy='productListItem'][1]/div/a//div/text()[1]")));
    }
}
