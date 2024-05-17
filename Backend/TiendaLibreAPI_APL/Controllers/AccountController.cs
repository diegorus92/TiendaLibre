using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_BL.Services;

namespace TiendaLibreAPI_APL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }



        [HttpPost("register")]
        public async Task<ActionResult> Register(UserRegisterAccountDto userRegisterAccountDto)
        {
            var result = await _accountService.RegisterUser(userRegisterAccountDto);
            if(result.GetType() == typeof(string)) BadRequest(result);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<AccessDataUserDTO>> Login(UserLoginDTO userLoginDto)
        {
            AccessDataUserDTO? accessDataUserDto = null;
            try
            {
                accessDataUserDto = await _accountService.LoginUser(userLoginDto);
                return Ok(accessDataUserDto);      
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
