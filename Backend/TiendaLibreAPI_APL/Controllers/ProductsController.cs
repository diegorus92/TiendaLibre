using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_BL.Services;

namespace TiendaLibreAPI_APL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public async Task<ActionResult> AddProduct(ProductPostDTO productPostDto)
        {
            try
            {
                await _productService.AddProduct(productPostDto);
                return Ok($"Product: {productPostDto.ProductName}-{productPostDto.ProductBrand}-{productPostDto.ProductModel} added to seller ID: {productPostDto.UserSellerId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ProductDTO>>> GetProducts()
        {
            ICollection<ProductDTO> productDtos = new List<ProductDTO>();
            productDtos = await _productService.GetProducts();
            return Ok(productDtos);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(long productId, ProductUpdateDTO productUpdateDto)
        {
            try
            {
                await _productService.UpdateProduct(productId, productUpdateDto);
                return Ok($"Product updated: --> {productId} - {productUpdateDto.ProductName}-{productUpdateDto.ProductBrand}-{productUpdateDto.ProductModel}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
