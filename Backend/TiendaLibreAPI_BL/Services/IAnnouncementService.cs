using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_DAL.Models;

namespace TiendaLibreAPI_BL.Services
{
    public interface IAnnouncementService
    {
        public Task SendAnnouncementToUsers(AnnouncementToPostDTO announcementToPostDto);

        public Task<ICollection<Announcement>> GetAllAnnouncements();
    }
}
