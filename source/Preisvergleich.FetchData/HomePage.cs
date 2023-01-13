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

    public float GetPrice(string searchInput)
    {
        WebUiDriver.driver.Navigate().GoToUrl(homePageMap.Url);
        homePageMap.SearchInputField.SendKeys(searchInput);
        string resultString = homePageMap.FirstResultPrice.Text;
        return StringToFloat(resultString);
    }

    public float StringToFloat(string resultString)
    {
        string convertedString = "";
        for (int i = 0; i < resultString.Length; i++)
        {
            if (Char.IsDigit(resultString[i]) || (resultString[i].Equals(Char.Parse(".")) && Char.IsDigit(resultString[i + 1])))
            {
                convertedString += resultString[i];
            }
        }

        return float.Parse(convertedString);
    }
}