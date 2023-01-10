using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels
{
    public class DigitecHomePageMap : IHomePageMap
    {
        public string Url { get { return "https://www.digitec.ch/"; } }
        public IWebElement SearchInputField
        {
            get
            {
                return WebUiDriver.driver.FindElement(By.XPath("//input[@placeholder='Suche nach Produkten, Kategorien, Marken und mehr']"));
            }
        }

        public IWebElement FirstResultPrice
        {
            get
            {
                return WebUiDriver.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//form[@action='/search']//div/section/ul/li[1]/div/div/span/strong")));
            }
        }
    }
}
