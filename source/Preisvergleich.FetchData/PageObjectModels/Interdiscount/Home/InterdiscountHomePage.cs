using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels.Interdiscount.Home
{
    public static class InterdiscountHomePage
    {
        public static void NavigateTo()
        {
            WebUiDriver.driver.Navigate().GoToUrl(InterdiscountHomePageMap.Url);
        }

        public static void SearchFor(string searchInput)
        {
            InterdiscountHomePageMap.SearchInputField.SendKeys(searchInput);
            InterdiscountHomePageMap.ExecuteSearchButton.Click();
        }
    }
}
