using Microsoft.VisualStudio.TestPlatform.ObjectModel.DataCollection;
using Moq;
using OpenQA.Selenium;
using Preisvergleich.FetchData.PageObjectModels;
using System.Diagnostics;

namespace Preisvergleich.FetchData.Tests
{
    [TestClass]
    public class HomePageTests
    {
        private HomePage homePage;
        private Mock<IHomePageMap> homePageMapMock;
        private Mock<HomePage> homePageMock;
        private Mock<IWebDriver> webDriverMock = new Mock<IWebDriver>();

        [TestInitialize]
        public void HomePage_Setup()
        {
            webDriverMock.Setup(_ => _.Navigate().GoToUrl(It.IsAny<string>()));
            WebUiDriver.driver = webDriverMock.Object;

            homePageMapMock = new Mock<IHomePageMap>();
            homePageMapMock.Setup(_ => _.Url).Returns("https://www.microspot.ch/");
            homePageMapMock.Setup(_ => _.SearchInputField).Returns(new Mock<IWebElement>().Object);
        }

        [DataRow("1000", "iPhone 12 128GB", 1000f)]
        [DataRow("590", "Samsung S22 64GB", 590f)]
        [DataRow("760", "iPhone 13 64GB", 760f)]
        [TestMethod]
        public void HomePage_GetPrice_WithNormalNumber_ExpectedResult(string price, string product, float expectedResult)
        {
            // Arrange
            homePageMock = new Mock<HomePage>();
            homePageMock.Setup(_ => _.StringToFloat(It.IsAny<string>())).Returns(expectedResult);

            homePageMapMock.Setup(_ => _.FirstResultPrice.Text).Returns(price);
            homePage = new HomePage(homePageMapMock.Object);

            // Act
            float result = homePage.GetPrice(product);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }

        [DataRow("999", 999f)]
        [DataRow("550", 550f)]
        [DataRow("320", 320f)]
        [TestMethod]
        public void HomePage_StringToFloat_WithNormalNumber_ExpectedResult(string price, float expectedResult)
        {
            // Arrange
            homePage = new HomePage(homePageMapMock.Object);

            // Act
            float result = homePage.StringToFloat(price);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}