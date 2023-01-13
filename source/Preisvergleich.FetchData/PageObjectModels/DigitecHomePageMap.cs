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

        /// <summary>
        /// locates the search input field on a website
        /// </summary>
        public IWebElement SearchInputField
        {
            get
            {
                // Use XPath to locate the input field by its placeholder attribute
                return WebUiDriver.driver.FindElement(By.XPath("//input[@placeholder='Suche nach Produkten, Kategorien, Marken und mehr']"));
            }
        }

        /// <summary>
        /// Locates the first result price element on a website
        /// </summary>
        public IWebElement FirstResultPrice
        {
            get
            {
                // Use XPath to locate the price element by its location in the HTML structure,
                // and use the WebDriverWait to wait until the element is visible
                return WebUiDriver.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//form[@action='/search']//div/section/ul/li[1]/div/div/span/strong")));
            }
        }
    }
}
