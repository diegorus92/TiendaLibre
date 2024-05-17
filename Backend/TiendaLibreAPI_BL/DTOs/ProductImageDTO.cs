using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibreAPI_BL.DTOs
{
    public class ProductImageDTO
    {
        public long ProductImageId { get; set; }
        public string ProductImageName { get; set; }
        public Byte[] DataImage { get; set; } = [];
    }
}
