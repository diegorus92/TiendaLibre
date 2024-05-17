using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_DAL.Models;

namespace TiendaLibreAPI_BL.Services
{
    public interface IPurchaseOperationService
    {
        public Task<ICollection<Purchase>> BuyProducts(List<PurchaseDTO> purchasesDto);
        public Task<Purchase> _ExecutePurchase(PurchaseDTO purchaseDto, User userCostumer, Product productToBuy);
        public Task<ICollection<PurchaseBasicInfoDTO>> GetAllPurchases();
    }
}
