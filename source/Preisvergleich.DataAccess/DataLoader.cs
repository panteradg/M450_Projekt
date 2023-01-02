using Newtonsoft.Json;
using Preisvergleich.DataAccess.Models;

namespace Preisvergleich.DataAccess
{
    public class DataLoader
    {
        public DataLoader()
        {
            using (StreamReader reader = new StreamReader("../../../../Preisvergleich.DataAccess/inputData.json"))
            {
                string json = reader.ReadToEnd();
                var jsonResult = JsonConvert.DeserializeAnonymousType(json, new { Webseiten = new List<Webseite>(), Produkte = new List<Produkt>() });
                this.Webseiten = jsonResult.Webseiten;
                this.Produkte = jsonResult.Produkte;
            }
        }

        public List<Webseite> Webseiten { get; }
        public List<Produkt> Produkte { get; }
    }
}