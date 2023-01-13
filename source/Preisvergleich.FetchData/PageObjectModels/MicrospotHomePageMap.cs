using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels
{
    public class MicrospotHomePageMap : IHomePageMap
    {
        public string Url { get { return "https://www.microspot.ch/"; } }

        /// <summary>
        /// locates the search input field on a website
        /// </summary>
        public IWebElement SearchInputField
        {
            get
            {
                // Use XPath to locate the input field by its unique id
                return WebUiDriver.driver.FindElement(By.Id("formControl-inputSearchDesktop-input"));
            }
        }

        /// <summary>
        /// Locates the first result price element on a website
        /// </summary>
        public IWebElement FirstResultPrice
        {
            get
            {
                // Use xPath to locate the price element by its data-cy attribute and its location in the HTML structure,
                // and use the WebDriverWait to wait until the element is visible
                return WebUiDriver.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-cy='searchProduct'][1]//span[2]")));
            }
        }
    }
}
