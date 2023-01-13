using Preisvergleich.FetchData;
using Preisvergleich.DataAccess;
using Preisvergleich.FetchData.PageObjectModels;

WebUiDriver.Init();

// Remove Code after, just for testing purposes
DataLoader dataLoader = new DataLoader();

HomePage digitecHomePage = new HomePage(new DigitecHomePageMap());
float resultDigitec = digitecHomePage.GetPrice(dataLoader.Produkte.First().Name);

HomePage interdiscountHomePage = new HomePage(new InterdiscountHomePageMap());
float resultInterdiscount = interdiscountHomePage.GetPrice("ip");

HomePage microspotHomePage = new HomePage(new MicrospotHomePageMap());
float resultMicrospot = microspotHomePage.GetPrice("ip");


Console.ReadKey();