using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_DAL.Data;
using TiendaLibreAPI_DAL.Models;

namespace TiendaLibreAPI_BL.Services
{
    public class PurchaseOperationService : IPurchaseOperationService
    {
        private readonly DatabaseContext _dbContext;

        public PurchaseOperationService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<ICollection<Purchase>> BuyProducts(List<PurchaseDTO> purchasesDto)
        {
            List<Purchase> purchasesAdded = new List<Purchase>();

            foreach(var purchaseDto in purchasesDto)
            {
                Product? productToBuy = await _dbContext.Products.FirstOrDefaultAsync(product =>
                product.ProductId == purchaseDto.ProductId);
                if (productToBuy == null) throw new Exception("Product not found");

                if (purchasesDto.FindAll(purchase =>
                    purchase.ProductId == purchaseDto.ProductId).Count() > 1)
                        throw new Exception("Duplicate product purchase error.\n " +
                            "If you want to buy the same product more than once, " +
                            "please add <Qty To Buy> number in the same purchase for that");

                User? userCostumer = await _dbContext.Users.FirstOrDefaultAsync(user =>
                    user.UserId == purchaseDto.UserCostumerId);
                if (userCostumer == null) throw new Exception("Costumer not found");

                //Purchase process
                //Stock decreesing
                purchasesAdded.Add(await _ExecutePurchase(purchaseDto, userCostumer, productToBuy));
            }
            
            await _dbContext.SaveChangesAsync();
            await _dbContext.DisposeAsync();
            return purchasesAdded;
        }

        //Apply stock disscount and add (without saving changes) a new Purchase entity in Database
        public async Task<Purchase> _ExecutePurchase(PurchaseDTO purchaseDto, User userCostumer, Product productToBuy)
        {
            if ((productToBuy.StockQty == 0) || (productToBuy.StockQty < purchaseDto.QtyToBuy)) 
                throw new Exception("Insuficient stock for this purchase");

            productToBuy.StockQty -= purchaseDto.QtyToBuy;
            _dbContext.Products.Update(productToBuy);

            Purchase costumerPurchase = new Purchase
            {
                Product = productToBuy,
                QtyToBuy = purchaseDto.QtyToBuy,
                UserCostumer = userCostumer
            };

            await _dbContext.Purchases.AddAsync(costumerPurchase);
            return costumerPurchase;
        }


        public async Task<ICollection<PurchaseBasicInfoDTO>> GetAllPurchases()
        {
            List<Purchase> purchases = new List<Purchase>();
            List<PurchaseBasicInfoDTO> purchasesInfo = new List<PurchaseBasicInfoDTO>();

            purchases = await _dbContext.Purchases.
                Include(purchase => purchase.Product).
                Include(purchase => purchase.Product.ProductUserSeller).
                Include(purchase => purchase.UserCostumer).ToListAsync();

            foreach(var purchase in purchases)
            {
                purchasesInfo.Add(new PurchaseBasicInfoDTO
                {
                    PurchaseId = purchase.PurchaseId,
                    ProductName = $"{purchase.Product.ProductName} - {purchase.Product.ProductBrand} // {purchase.Product.ProductModel}",
                    PurchaseDate = purchase.DateOfPurchase,
                    UserCostumerId = purchase.UserCostumer.UserId,
                    UserCostumerFullName = purchase.UserCostumer.UserLastName + " " + purchase.UserCostumer.UserName,
                    UserSellerId = purchase.Product.ProductUserSeller.UserId,
                    UserSellerFullName = purchase.Product.ProductUserSeller.UserLastName + " " + purchase.Product.ProductUserSeller.UserName
                });
            }

            return purchasesInfo;
        }

    }
}
