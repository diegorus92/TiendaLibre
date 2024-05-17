using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibreAPI_BL.DTOs
{
    public class ProductUpdateDTO
    {
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string ProductBrand { get; set; }
        public string ProductModel { get; set; }
        public float Price { get; set; }
        public int StockQty { get; set; }
    }
}
