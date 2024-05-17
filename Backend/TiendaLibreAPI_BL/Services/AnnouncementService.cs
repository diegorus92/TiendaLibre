using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_DAL.Data;
using TiendaLibreAPI_DAL.Models;

namespace TiendaLibreAPI_BL.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly DatabaseContext _dbContext;

        public AnnouncementService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SendAnnouncementToUsers(AnnouncementToPostDTO announcementToPostDto)
        {
            Purchase? costumerPurchase = await _dbContext.Purchases.Include(purchase => purchase.Product).FirstOrDefaultAsync(purchase =>
                                            purchase.PurchaseId == announcementToPostDto.PurchaseId);
            if (costumerPurchase == null) throw new Exception("Purchase not found");

            User? userCostumer = await _dbContext.Users.FirstOrDefaultAsync(user => 
                                            user.UserId == announcementToPostDto.UserCostumerId);
            if (userCostumer == null) throw new Exception("Costumer not found");

            Product? productSelled = await _dbContext.Products.Include(product => product.ProductUserSeller).FirstOrDefaultAsync(product =>
                                             product.ProductId == announcementToPostDto.ProductSelledId);
            if (productSelled == null) throw new Exception("Product not found");



            //Message for the costumer
            Announcement announcementToCostumer = new Announcement()
            {
                AnnouncementMessage = $"You have purchased: {costumerPurchase.QtyToBuy} -> {costumerPurchase.Product.ProductName} {costumerPurchase.Product.ProductBrand}",
                UserReceiverId = userCostumer.UserId,
                Purchase = costumerPurchase
            };

            //Message for the seller
            Announcement announcementToSeller = new Announcement()
            {
                AnnouncementMessage = $"You have a new sell: {costumerPurchase.Product.ProductName} {costumerPurchase.Product.ProductBrand} by {userCostumer.UserLastName} {userCostumer.UserName}",
                UserReceiverId = productSelled.ProductUserSeller.UserId,
                Purchase = costumerPurchase
            };

            List<Announcement> announcementsToSend = new List<Announcement>();
            announcementsToSend.Add(announcementToCostumer);
            announcementsToSend.Add(announcementToSeller);

            await _dbContext.Announcements.AddRangeAsync(announcementsToSend);
            await _dbContext.SaveChangesAsync();
            await _dbContext.DisposeAsync();
        }

        public async Task<ICollection<Announcement>> GetAllAnnouncements()
        {
            ICollection<Announcement> announcements = new List<Announcement>();
            announcements = await _dbContext.Announcements.
                Include(announcement => announcement.Purchase.Product).
                ToListAsync();
            return announcements;
        }
    }
}
