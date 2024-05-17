using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_BL.Services;

namespace TiendaLibreAPI_APL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public async Task<ActionResult<ICollection<UserDTO>>> GetUsers() 
        {
            ICollection<UserDTO> usersDtos = new List<UserDTO>();
            usersDtos = await _userService.GetUsers();
            return Ok(usersDtos);
        }
    }
}
