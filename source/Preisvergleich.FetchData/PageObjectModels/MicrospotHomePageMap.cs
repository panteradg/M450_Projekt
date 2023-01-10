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
        public IWebElement SearchInputField
        {
            get
            {
                return WebUiDriver.driver.FindElement(By.Id("formControl-inputSearchDesktop-input"));
            }
        }

        public IWebElement FirstResultPrice
        {
            get
            {
                return WebUiDriver.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-cy='searchProduct'][1]//span[2]")));
            }
        }
    }
}
