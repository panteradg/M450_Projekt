using Preisvergleich.FetchData;
using Preisvergleich.DataAccess;
using Preisvergleich.FetchData.PageObjectModels;

WebUiDriver.Init();


HomePage digitecHomePage = new HomePage(new DigitecHomePageMap());
HomePage interdiscountHomePage = new HomePage(new InterdiscountHomePageMap());
HomePage microspotHomePage = new HomePage(new MicrospotHomePageMap());

DataLoader dataLoader = new DataLoader();

foreach (string produkt in dataLoader.Products)
{
    foreach (Website website in Enum.GetValues(typeof(Website)))
    {
        decimal result;
        switch (website)
        {
            case Website.Digitec:
                result = digitecHomePage.GetPrice(produkt);
                break;
            case Website.Interdiscount:
                result = interdiscountHomePage.GetPrice(produkt);
                break;
            case Website.Microspot:
                result = microspotHomePage.GetPrice(produkt);
                break;
          default:
                throw new ArgumentOutOfRangeException();
        }
        dataLoader.AddProduct(produkt, website, result);
    }
}

dataLoader.SaveData();

WebUiDriver.driver.Close();