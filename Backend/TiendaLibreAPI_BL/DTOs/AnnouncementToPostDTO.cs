using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibreAPI_BL.DTOs
{
    public class AnnouncementToPostDTO
    {
        //Purchase costumerPurchase, User userCostumer, Product productToBuy
        public long PurchaseId {  get; set; }
        public long UserCostumerId { get; set; }
        public long ProductSelledId { get; set; }
    }
}
