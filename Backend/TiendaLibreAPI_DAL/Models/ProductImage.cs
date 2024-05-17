using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibreAPI_DAL.Models
{
    public class ProductImage
    {
        public long ProductImageId { get; set; }
        public string ProductImageName { get; set; }
        public Product Product { get; set; }
    }
}
