using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Preisvergleich.DataAccess
{
    public class ProductFromWebsite
    {
        public decimal Price { get; set; }
        public string Product { get; set; }
        public string Website { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
