using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibreAPI_DAL.Models
{
    public class Product
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string ProductBrand { get; set; }
        public string ProductModel { get; set; }
        public float Price { get; set; }
        public int StockQty { get; set; } = 1;

        public User ProductUserSeller { get; set; }
    }
}
