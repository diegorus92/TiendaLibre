using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibreAPI_DAL.Models
{
    public class Purchase
    {
        public long PurchaseId { get; set; }
        public Product Product { get; set; }
        public string PurchaseState { get; set; } = "In preparation";
        public DateTime DateOfPurchase { get; set; } = DateTime.Now;
        public int QtyToBuy { get; set; } = 1;
        public User UserCostumer { get; set; }
        
    }
}
