using Preisvergleich.FetchData.PageObjectModels;
using System.Text.RegularExpressions;

namespace Preisvergleich.FetchData;
public class HomePage
{
    private readonly IHomePageMap homePageMap;
    public HomePage(IHomePageMap homePageMap)
    {
        this.homePageMap = homePageMap;
    }

    public int GetPrice(string searchInput)
    {
        WebUiDriver.driver.Navigate().GoToUrl(homePageMap.Url);
        homePageMap.SearchInputField.SendKeys(searchInput);
        string stringPrice = homePageMap.SearchInputField.Text;
        return int.Parse(Regex.Match(stringPrice, @"\d+").Value);
    }
}