using OpenQA.Selenium;
using Preisvergleich.FetchData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels.Digitec.SearchResult
{
    public static class DigitecSearchResultPage
    {
        public static int GetPrice()
        {
            // Takes only the numbers from the string
            return int.Parse(Regex.Match(DigitecSearchResultPageMap.GetPrice.Text, @"\d+").Value);
        }
    }
}
