using Newtonsoft.Json;

namespace Preisvergleich.DataAccess
{
    public class DataLoader
    {
        public DataLoader()
        {
            using (StreamReader reader = new StreamReader("../../../../Preisvergleich.DataAccess/inputData.json"))
            {
                string jsonInput = reader.ReadToEnd();
                Products = JsonConvert.DeserializeObject<List<string>>(jsonInput);
                reader.Close();
            }

            using (StreamReader reader = new StreamReader("../../../../Preisvergleich.DataAccess/outputData.json"))
            {
                string jsonOutput = reader.ReadToEnd();
                ProductFromWebsiteListList = JsonConvert.DeserializeObject<List<List<ProductFromWebsite>>>(jsonOutput);
                reader.Close();
            }
        }

        public void AddProduct(string product, Website website, decimal price)
        {
            ProductsFromWebsite.Add(new ProductFromWebsite()
            {
                Price = price,
                Product = product,
                Website = website.ToString(),
                Timestamp = DateTime.Now
            });
        }

        public void SaveData()
        {
            using (StreamReader reader = new StreamReader("../../../../Preisvergleich.DataAccess/outputData.json"))
            {
                string outputDataJson = reader.ReadToEnd();
                ProductFromWebsiteListList = JsonConvert.DeserializeObject<List<List<ProductFromWebsite>>>(outputDataJson);
                reader.Close();
            }

            // Copy by value, without reference
            ProductFromWebsiteListList.Add(new List<ProductFromWebsite>(ProductsFromWebsite));
            string json = JsonConvert.SerializeObject(ProductFromWebsiteListList, Formatting.Indented);

            File.WriteAllLines("../../../../Preisvergleich.DataAccess/outputData.json", new[] { json });
            ProductsFromWebsite.Clear();
        }

        private List<ProductFromWebsite> ProductsFromWebsite { get; set; } = new List<ProductFromWebsite>();
        public List<List<ProductFromWebsite>> ProductFromWebsiteListList = new List<List<ProductFromWebsite>>();
        public List<string> Products { get; }
    }
}