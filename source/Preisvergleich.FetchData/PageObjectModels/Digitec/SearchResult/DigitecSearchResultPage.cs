using OpenQA.Selenium;
using Preisvergleich.FetchData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels.Digitec.SearchResult
{
    public static class DigitecSearchResultPage
    {
        public static string GetPrice()
        {
           return DigitecSearchResultPageMap.GetPrice.Text;
        }
    }
}
