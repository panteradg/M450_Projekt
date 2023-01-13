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

    /// <summary>
    /// Gets the price of a product by searching for it on a website
    /// </summary>
    /// <param name="searchInput"></param>
    /// <returns>Price of the product</returns>
    public float GetPrice(string searchInput)
    {
        WebUiDriver.driver.Navigate().GoToUrl(homePageMap.Url);
        homePageMap.SearchInputField.SendKeys(searchInput);
        string resultString = homePageMap.FirstResultPrice.Text;
        return StringToFloat(resultString);
    }

    /// <summary>
    /// Converts a string value to float
    /// </summary>
    /// <param name="resultString"></param>
    /// <returns>Float value of the string</returns>
    public float StringToFloat(string resultString)
    {
        string convertedString = "";
        for (int i = 0; i < resultString.Length; i++)
        {
            // Checks if the character is a digit or if it's a "." followed by a digit
            if (Char.IsDigit(resultString[i]) || (resultString[i].Equals(Char.Parse(".")) && Char.IsDigit(resultString[i + 1])))
            {
                convertedString += resultString[i];
            }
        }

        return float.Parse(convertedString);
    }
}