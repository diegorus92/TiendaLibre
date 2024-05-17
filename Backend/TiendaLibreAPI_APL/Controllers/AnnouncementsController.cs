using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_BL.Services;
using TiendaLibreAPI_DAL.Models;

namespace TiendaLibreAPI_APL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementsController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }



        [HttpPost]
        public async Task<ActionResult> SendAnnouncementsToUsers(AnnouncementToPostDTO announcementToPostDto)
        {
            try
            {
                await _announcementService.SendAnnouncementToUsers(announcementToPostDto);
                return Ok("The announcements was correctly sended to costumer and seller");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Announcement>>> GetAllAnnouncements()
        {
            ICollection<Announcement> announcements = await _announcementService.GetAllAnnouncements();
            return Ok(announcements);
        }
    }
}
