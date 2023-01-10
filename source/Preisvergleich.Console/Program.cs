using Preisvergleich.FetchData;
using Preisvergleich.DataAccess;
using Preisvergleich.FetchData.PageObjectModels;

WebUiDriver.Init();

// Remove Code after, just for testing purposes
DataLoader dataLoader = new DataLoader();

HomePage digitecHomePage = new HomePage(new DigitecHomePageMap());
decimal resultDigitec = digitecHomePage.GetPrice(dataLoader.Produkte.First().Name);

HomePage interdiscountHomePage = new HomePage(new InterdiscountHomePageMap());
decimal resultInterdiscount = interdiscountHomePage.GetPrice("ip");

HomePage microspotHomePage = new HomePage(new MicrospotHomePageMap());
decimal resultMicrospot = microspotHomePage.GetPrice("ip");


Console.ReadKey();