using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_BL.Services;

namespace TiendaLibreAPI_APL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;


        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }


        [HttpPost]
        public async Task<ActionResult<string>> AddProductImages(ICollection<IFormFile> imageFiles, long productId)
        {
            try
            {
                var message = await _productImageService.AddProductImages(imageFiles, productId);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductImageDTO>>> GetProductImages(long productId)
        {
            var images = await _productImageService.GetProductImages(productId);
            List<ProductImageDTO> listImages = images.ToList();
            return Ok(listImages);
        }



        //This return the image rendered into endpoint
        /*[HttpGet]
        [Produces ("image/jpg")]
        public async Task<ActionResult> GetProductImages(long productId)
        {
            var images = await _productImageService.GetProductImages(productId);
            List<Byte[]> listImages = images.ToList();
            return File(listImages[0], "image/jpg");
        }*/
    }
}
