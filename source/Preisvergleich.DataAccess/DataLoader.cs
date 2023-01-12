using Newtonsoft.Json;

namespace Preisvergleich.DataAccess
{
    public class DataLoader
    {
        public DataLoader()
        {
            using (StreamReader reader = new StreamReader("../../../../Preisvergleich.DataAccess/inputData.json"))
            {
                string json = reader.ReadToEnd();
                Products = JsonConvert.DeserializeObject<List<string>>(json);
            }
        }

        public void AddProduct(string product, Website website, decimal price)
        {
            ProductsFromWebsite.Add(new ProductFromWebsite()
            {
                Price = price,
                Product = product,
                Website = website,
                Timestamp = DateTime.Now
            });
        }

        public bool SaveData()
        {
            string json = JsonConvert.SerializeObject(ProductsFromWebsite);

            using (StreamWriter writer = File.AppendText("../../../../Preisvergleich.DataAccess/outputData.json"))
            {
                writer.WriteLine(json);
            };
            return false;
        }
        
        public List<ProductFromWebsite> ProductsFromWebsite { get; set; }
        public List<string> Products { get; }
    }
}