using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.DataAccess.Models
{
    internal class ProduktVonWebseite
    {
        public decimal Preis { get; set; }
        public Webseite Webseite { get; set; }
        public Produkt Produkt { get; set; }
    }
}
