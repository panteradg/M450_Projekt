using System;
using Preisvergleich.FetchData;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.FetchData.PageObjectModels.Interdiscount.SearchResult
{
    public static class InterdiscountSearchResultPage
    {
        public static int GetPrice()
        {
            return int.Parse(InterdiscountSearchResultPageMap.GetPrice.Text);
        }
    }
}
