using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_DAL.Data;
using TiendaLibreAPI_DAL.Migrations;
using TiendaLibreAPI_DAL.Models;


namespace TiendaLibreAPI_BL.Services
{
    public class AccountService : IAccountService
    {
        private readonly DatabaseContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly SymmetricSecurityKey _symetricKey;
        private readonly IImageFileManagerService _imageFileManager;
        private readonly IPasswordEncryptationService _passwordEncryptation;
        private readonly ITokenService _tokenService;
        private readonly string _userImageFilePath;

        public AccountService(DatabaseContext dbContext, IConfiguration configuration,
            IImageFileManagerService imageFileManager, IPasswordEncryptationService passwordEncryptation, ITokenService tokenService)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _symetricKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["TokenKey"]));
            _imageFileManager = imageFileManager;
            _passwordEncryptation = passwordEncryptation;
            _tokenService = tokenService;
            _userImageFilePath = "Assets\\Images";
        }



        public async Task<Object> RegisterUser(UserRegisterAccountDto userRegisterAccountDto)
        {
            User? user = await _dbContext.Users.FirstOrDefaultAsync<User>(user =>
                (user.UserDni == userRegisterAccountDto.UserDni) ||
                (user.UserEmail.ToLower() == userRegisterAccountDto.UserEmail.ToLower()));

            if (user != null) return "User already exist";

            //Registrate new user
            if (userRegisterAccountDto.UserPassword != userRegisterAccountDto.UserRepeatedPassword)
                return "Password and repeated Password must be equals!";

            //New User creation to register
            user = new User()
            {
                UserDni = userRegisterAccountDto.UserDni,
                UserName = userRegisterAccountDto.UserName,
                UserLastName = userRegisterAccountDto.UserLastName,
                UserAddress = userRegisterAccountDto.UserAddress,
                UserBirthdate = userRegisterAccountDto.UserBirthdate,
                UserCellphone = userRegisterAccountDto.UserCellphone,
                UserEmail = userRegisterAccountDto.UserEmail,
                UserCountry = userRegisterAccountDto.UserCountry,
                UserCity = userRegisterAccountDto.UserCity,
                UserPwHash = Array.Empty<Byte>(),
                UserPwSalt = Array.Empty<Byte>(),
                ProfileImageName = String.Empty,
            };

            //Encryptation and saving password
            _passwordEncryptation.EncryptPassword(user, userRegisterAccountDto.UserPassword);

            //Gerenate token
            string token = _tokenService.CreateToken(user, _symetricKey);

            //Saving profile image user if exist
            if (userRegisterAccountDto.UserProfileImage != null)
            {
                string imagePathResult = _imageFileManager.SaveImageFile(userRegisterAccountDto.UserProfileImage, _userImageFilePath);
                if (imagePathResult.Length > 0)
                    user.ProfileImageName = imagePathResult;
            }

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync(); 
            await _dbContext.DisposeAsync();

            return new AccessDataUserDTO { UserId = user.UserId, UserEmail = user.UserEmail, Token = token };
        }


        public async Task<AccessDataUserDTO> LoginUser(UserLoginDTO userloginDto)
        {
            User? user = await _dbContext.Users.FirstOrDefaultAsync(user =>
                user.UserEmail.ToLower() == userloginDto.UserEmail.ToLower());
            
            //User existence verification
            if (user == null)  throw new Exception("Invalid credentials");

            //User Pw verification
            if (!_passwordEncryptation.ValidatePassword(user.UserPwHash, user.UserPwSalt, userloginDto.Password))
                throw new Exception("Invalid credentials");

            return new AccessDataUserDTO { UserId = user.UserId, UserEmail = user.UserEmail, Token = _tokenService.CreateToken(user, _symetricKey) };
        }
        
    }
}
