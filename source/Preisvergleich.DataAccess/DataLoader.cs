using Newtonsoft.Json;

namespace Preisvergleich.DataAccess
{
    public class DataLoader
    {
        public DataLoader()
        {
            // Read in data from inputData.json and deserialize it into a List of strings
            using (StreamReader reader = new StreamReader("../../../../Preisvergleich.DataAccess/inputData.json"))
            {
                string jsonInput = reader.ReadToEnd();
                Products = JsonConvert.DeserializeObject<List<string>>(jsonInput);
                reader.Close();
            }

            // Read in data from outputData.json and deserialize it into a List of List of ProductFromWebsite objects
            using (StreamReader reader = new StreamReader("../../../../Preisvergleich.DataAccess/outputData.json"))
            {
                string jsonOutput = reader.ReadToEnd();
                ProductFromWebsiteListList = JsonConvert.DeserializeObject<List<List<ProductFromWebsite>>>(jsonOutput);
                reader.Close();
            }
        }

        public void AddProduct(string product, Website website, float price)
        {
            // Add a new ProductFromWebsite object to the ProductsFromWebsite list
            ProductsFromWebsite.Add(new ProductFromWebsite()
            {
                Price = price,
                Product = product,
                Website = Enum.GetName(typeof(Website), website),
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