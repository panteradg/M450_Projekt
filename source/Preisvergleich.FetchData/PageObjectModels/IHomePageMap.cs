using OpenQA.Selenium;

namespace Preisvergleich.FetchData.PageObjectModels;
public interface IHomePageMap
{
    string Url { get; }
    public IWebElement SearchInputField { get; }
    public IWebElement FirstResultPrice { get; }
}