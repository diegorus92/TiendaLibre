using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaLibreAPI_BL.DTOs;

namespace TiendaLibreAPI_BL.Services
{
    public interface IProductService
    {
        public Task AddProduct(ProductPostDTO productPostDto);
        public Task<ICollection<ProductDTO>> GetProducts();
        public Task UpdateProduct(long productId, ProductUpdateDTO productUpdateDto);
    }
}
