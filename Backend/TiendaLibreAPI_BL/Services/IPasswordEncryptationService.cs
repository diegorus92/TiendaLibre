using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaLibreAPI_DAL.Models;

namespace TiendaLibreAPI_BL.Services
{
    public interface IPasswordEncryptationService
    {
        public void EncryptPassword(User user, string password);
        public bool ValidatePassword(Byte[] passwordHash, Byte[] passwordSalt, string password);

    }
}
