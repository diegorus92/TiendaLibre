using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_BL.Services;
using TiendaLibreAPI_DAL.Models;

namespace TiendaLibreAPI_APL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasesController : ControllerBase
    {
        private readonly IPurchaseOperationService _purchaseOpServices;

        public PurchasesController(IPurchaseOperationService purchaseOpServices)
        {
            _purchaseOpServices = purchaseOpServices;
        }


        [HttpPost]
        public async Task<ActionResult> BuyProducts(List<PurchaseDTO> purchasesDto)
        {
            try
            {
                await _purchaseOpServices.BuyProducts(purchasesDto);
                return Ok("Purchases done!");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<PurchaseBasicInfoDTO>>> GetAllPurchases()
        {
            return Ok(await _purchaseOpServices.GetAllPurchases());
        }
    }
}
