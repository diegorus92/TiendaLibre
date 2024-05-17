using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibreAPI_BL.DTOs
{
    public class PurchaseBasicInfoDTO
    {
        public long PurchaseId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string ProductName { get; set; }
        public long UserCostumerId { get; set; }
        public string UserCostumerFullName { get; set; }
        public long UserSellerId { get; set; }
        public string UserSellerFullName { get; set; }
    }
}
