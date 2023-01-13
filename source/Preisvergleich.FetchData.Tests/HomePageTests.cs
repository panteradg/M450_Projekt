using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Moq;
using OpenQA.Selenium;
using Preisvergleich.FetchData.PageObjectModels;
using System.Diagnostics;

namespace Preisvergleich.FetchData.Tests
{
    /// <summary>
    /// Tests for the HomePage feature of the application
    /// </summary>
    [TestClass]
    public class HomePageTests
    {
        private HomePage homePage;
        private Mock<DigitecHomePageMap> digitecPageMapMock;
        private Mock<HomePage> homePageMock;
        private Mock<IWebDriver> webDriverMock = new Mock<IWebDriver>();

        /// <summary>
        /// Prepares mocks for upcoming test methods
        /// </summary>
        [TestInitialize]
        public void HomePage_Setup()
        {
            webDriverMock.Setup(_ => _.Navigate().GoToUrl(It.IsAny<string>()));
            WebUiDriver.driver = webDriverMock.Object;
            digitecPageMapMock = new Mock<DigitecHomePageMap>();
        }

        /// <summary>
        /// Gets price with a mock and compares it with expectedResult
        /// </summary>
        /// <param name="price"></param>
        /// <param name="product"></param>
        /// <param name="expectedResult"></param>
        [DataRow("1000", "iPhone 12 128GB", 1000f)]
        [DataRow("590", "Samsung S22 64GB", 590f)]
        [DataRow("760", "iPhone 13 64GB", 760f)]
        [TestMethod]
        public void HomePage_GetPrice_WithNormalNumber_ExpectedResult(string price, string product, float expectedResult)
        {
            // Arrange
            digitecPageMapMock.Setup(_ => _.FirstResultPrice).Returns(It.IsAny<IWebElement>());
            homePageMock = new Mock<HomePage>(digitecPageMapMock);
            homePageMock.Setup(_ => _.StringToFloat(It.IsAny<string>())).Returns(It.IsAny<float>());

            // Act
            float result = homePageMock.Object.GetPrice(product);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        /// <summary>
        /// Tests if price are parsed correctly
        /// </summary>
        /// <param name="price"></param>
        /// <param name="expectedResult"></param>
        [DataRow("999", 999f)]
        [DataRow("550", 550f)]
        [DataRow("320", 320f)]
        [TestMethod]
        public void HomePage_StringToFloat_WithNormalNumber_ExpectedResult(string price, float expectedResult)
        {
            // Arrange
            homePage = new HomePage(digitecPageMapMock.Object);

            // Act
            float result = homePage.StringToFloat(price);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}