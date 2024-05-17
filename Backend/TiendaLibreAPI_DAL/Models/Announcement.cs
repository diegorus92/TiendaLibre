using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibreAPI_DAL.Models
{
    public class Announcement
    {
        public long AnnouncementId { get; set; }
        public string AnnouncementMessage { get; set; } = string.Empty;
        public bool AnnouncementRead { get; set; } = false;
        public long UserReceiverId { get; set; }
        public Purchase Purchase { get; set; }
    }
}
