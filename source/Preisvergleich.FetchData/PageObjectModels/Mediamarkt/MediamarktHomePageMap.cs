using OpenQA.Selenium;
using Preisvergleich.FetchData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels.Mediamarkt
{
    public class MediamarktHomePageMap : IHomePageMap
    {
        public string Url { get { return "https://www.mediamarkt.ch/"; } }
        public IWebElement SearchInputField 
        { 
            get 
            { 
                return WebUiDriver.driver.FindElement(By.XPath("//input[@data-identifier='search-input-searchterm']")); 
            } 
        }
            
        public IWebElement ExecuteSearchButton
        {
            get
            {
                return WebUiDriver.driver.FindElement(By.XPath("//button[@aria-label='Execute search']"));
            }
        } 
    }
}
