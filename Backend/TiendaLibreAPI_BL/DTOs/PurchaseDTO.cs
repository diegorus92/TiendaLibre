using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaLibreAPI_DAL.Models;

namespace TiendaLibreAPI_BL.DTOs
{
    public class PurchaseDTO
    {
        public long ProductId { get; set; } //With ProductId we accessed to Product entity,
                                            //and from there we accessed to User (seller) entity
                                            //thats why we don't need User(seller)Id field

        public int QtyToBuy { get; set; } = 1;
        public long UserCostumerId { get; set; }

    }
}
