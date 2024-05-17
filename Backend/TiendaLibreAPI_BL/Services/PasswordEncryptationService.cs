using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TiendaLibreAPI_DAL.Models;

namespace TiendaLibreAPI_BL.Services
{
    public class PasswordEncryptationService : IPasswordEncryptationService
    {

        //Create Password Hash and Salt related to a password(string) and save it into User Entity
        public void EncryptPassword(User user, string password)
        {
            var hmac = new HMACSHA512();

            user.UserPwHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            user.UserPwSalt = hmac.Key;
        }

        public bool ValidatePassword(byte[] passwordHash, byte[] passwordSalt, string password)
        {
            var hmac = new HMACSHA512(passwordSalt);
            var encryptedPassword = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (int i = 0; i < encryptedPassword.Length; i++)
            {
                if (encryptedPassword[i] != passwordHash[i])
                    return false;
            }

            return true;
        }
    }
}
