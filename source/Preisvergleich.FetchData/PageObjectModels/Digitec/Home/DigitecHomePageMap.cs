using OpenQA.Selenium;
using Preisvergleich.FetchData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels.Digitec.Home
{
    internal static class DigitecHomePageMap
    {
        public static string Url = "https://www.digitec.ch/";
        public static IWebElement SearchInputField =>
            WebUiDriver.driver.FindElement(By.XPath("//input[@placeholder='Suche nach Produkten, Kategorien, Marken und mehr']"));
        public static IWebElement ExecuteSearchButton =>
            WebUiDriver.driver.FindElement(By.XPath("//button[@aria-label='Execute search']"));
        public static IWebElement ClosePopupButton =>
            WebUiDriver.driver.FindElement(By.XPath("//button[@aria-label='Schliessen']"));
    }
}
