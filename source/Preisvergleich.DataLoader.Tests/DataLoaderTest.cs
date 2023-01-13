using Preisvergleich.DataAccess;

namespace Preisvergleich.DataAccess.Tests
{
    [TestClass]
    public class DataLoaderTest
    {
        [TestMethod]
        public void DataLoader_AddProduct()
        {
            // Arrange
            DataLoader loader = new DataLoader();
            ProductFromWebsite product = new ProductFromWebsite()
            {
                Price = 123,
                Website = "Digitec",
                Product = "iPhone 14 Pro 256GB",
                Timestamp = DateTime.Now
            };

            // Act
            loader.AddProduct("Digitec", Website.Digitec, 123);

            // Assert
            Assert.AreEqual(loader.Products.Last(), product);
        }
    }
}