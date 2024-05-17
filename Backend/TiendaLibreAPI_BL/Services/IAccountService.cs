using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaLibreAPI_BL.DTOs;

namespace TiendaLibreAPI_BL.Services
{
    public interface IAccountService
    {
        public Task<Object> RegisterUser(UserRegisterAccountDto userRegisterAccountDto);
        public Task<AccessDataUserDTO> LoginUser(UserLoginDTO userloginDto);
    }
}
