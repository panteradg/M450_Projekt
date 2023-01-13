using FluentAssertions;
using Preisvergleich.DataAccess;
using Preisvergleich.FetchData;
using Preisvergleich.FetchData.PageObjectModels;
using TechTalk.SpecFlow;

namespace Gibz.CarParkManagement.AcceptanceTests.Steps;

[Binding]
public sealed class FetchDataSteps
{
    private float price;
    private Website usedWebsite;
    private DataLoader loader = new DataLoader();
    private readonly string product = "iPhone 14 Pro 256GB";

    [Given(@"the price is fetched from (.*)")]
    public void ThePriceIsFetchedFrom(string website)
    {
        IHomePageMap homePageMap;
        switch (website)
        {
            case "Digitec":
                homePageMap = new DigitecHomePageMap();
                usedWebsite = Website.Digitec;
                break;
            case "Interdiscount":
                homePageMap = new InterdiscountHomePageMap();
                usedWebsite = Website.Interdiscount;
                break;
            case "Microspot":
                homePageMap = new MicrospotHomePageMap();
                usedWebsite = Website.Microspot;
                break;
            default:
                homePageMap = null;
                break;
        }

        HomePage homePage = new HomePage(homePageMap);
        price = homePage.GetPrice(product);
    }

    [When(@"the price is saved to the Json File")]
    public void ThePriceIsSavedToTheJsonFile()
    {
        loader.AddProduct(product, usedWebsite, price);
        loader.SaveData();
    }

    [Then(@"the product is saved in the Json File with the correct price")]
    public void TheProductIsSavedInTheJsonFileWithTheCorrectPrice()
    {
        ProductFromWebsite expectedResult = new ProductFromWebsite()
        {
            Price = price,
            Product = product,
            Website = Enum.GetName(typeof(Website), usedWebsite)
        };
        
        ProductFromWebsite result = loader.ProductFromWebsiteListList.Last().FirstOrDefault();

        result.Should().Be(expectedResult);
    }
}