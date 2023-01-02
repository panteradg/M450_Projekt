using Preisvergleich.FetchData.PageObjectModels.Digitec.Home;
using Preisvergleich.FetchData.PageObjectModels.Digitec.SearchResult;
using Preisvergleich.FetchData;

WebUiDriver.Init();

// Remove Code after, just for testing purposes
DigitecHomePage.NavigateTo();
DigitecHomePage.SearchFor("iPhone 13 128GB");
DigitecSearchResultPage.GetPrice();