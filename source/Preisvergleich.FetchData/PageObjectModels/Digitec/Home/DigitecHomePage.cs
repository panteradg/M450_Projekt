using OpenQA.Selenium;
using Preisvergleich.FetchData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels.Digitec.Home
{
    public static class DigitecHomePage
    {
        public static void NavigateTo()
        {
            WebUiDriver.driver.Navigate().GoToUrl(DigitecHomePageMap.Url);
        }

        public static void SearchFor(string searchInput)
        {
            // Check if a popup came up, if it did, close it
            if (WebUiDriver.IsElementPresent(By.XPath("//button[@aria-label='Schliessen']")))
            {
                DigitecHomePageMap.ClosePopupButton.Click();
            }

            DigitecHomePageMap.SearchInputField.SendKeys(searchInput);
            DigitecHomePageMap.ExecuteSearchButton.Click();
        }
    }
}
