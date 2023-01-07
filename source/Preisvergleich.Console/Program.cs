using Preisvergleich.FetchData.PageObjectModels.Digitec.Home;
using Preisvergleich.FetchData.PageObjectModels.Digitec.SearchResult;
using Preisvergleich.FetchData;
using Preisvergleich.DataAccess;
using Preisvergleich.FetchData.PageObjectModels.Mediamarkt;

WebUiDriver.Init();

// Remove Code after, just for testing purposes
DataLoader dataLoader = new DataLoader();
HomePage mediamarktHomePage = new HomePage(new MediamarktHomePageMap());
mediamarktHomePage.NavigateTo();
mediamarktHomePage.SearchFor(dataLoader.Produkte.First().Name);