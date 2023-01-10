using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels
{
    public class InterdiscountHomePageMap : IHomePageMap
    {
        public string Url { get { return "https://www.interdiscount.ch/"; } }
        public IWebElement SearchInputField
        {
            get
            {
                return WebUiDriver.driver.FindElement(By.XPath("//input[@name='search']"));
            }
        }

        public IWebElement FirstResultPrice
        {
            get
            {
                return WebUiDriver.wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@data-cy='searchProduct'][1]/a/div/div/div")));
            }
        }
    }
}
