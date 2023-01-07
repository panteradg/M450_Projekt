using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels.Interdiscount.Home
{
    internal static class InterdiscountHomePageMap
    {
        public static string Url = "https://www.interdiscount.ch/";
        public static IWebElement SearchInputField =>
            WebUiDriver.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Stichwortsuche, Kategorien, Marken']")));
        public static IWebElement ExecuteSearchButton =>
            WebUiDriver.driver.FindElement(By.XPath("//button[@type='submit']"));
    }
}
