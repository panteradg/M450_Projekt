using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Preisvergleich.FetchData
{
    public static class WebUiDriver
    {
        public static IWebDriver driver = null;
        public static WebDriverWait wait = null;

        public static IWebDriver Init()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("ignore-certificate-errors");
            driver = new ChromeDriver(options);

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            return driver;
        }


        public static bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

            /*
            if (driver.FindElements(by).Count > 0)
            {
                return true;
            }
            return false;*/
        }
    }
}
