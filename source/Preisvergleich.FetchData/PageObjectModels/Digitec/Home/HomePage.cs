using OpenQA.Selenium;
using Preisvergleich.FetchData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels.Digitec.Home
{
    public static class HomePage
    {
        public static void NavigateTo()
        {
            WebUiDriver.driver.Navigate().GoToUrl(HomePageMap.Url);
        }

        public static void SearchFor(string searchInput)
        {
            // Check if a popup came up, if it did, close it
            if (WebUiDriver.IsElementPresent(By.XPath("//button[@aria-label='Schliessen']")))
            {
                HomePageMap.ClosePopupButton.Click();
            }

            HomePageMap.SearchInputField.SendKeys(searchInput);
            HomePageMap.ExecuteSearchButton.Click();
        }
    }
}
