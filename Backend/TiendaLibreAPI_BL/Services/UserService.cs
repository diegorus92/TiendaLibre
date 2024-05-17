using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_DAL.Data;
using TiendaLibreAPI_DAL.Models;

namespace TiendaLibreAPI_BL.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _dbContext;

        public UserService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<ICollection<UserDTO>> GetUsers()
        { 
            List<UserDTO> usersDtos = new List<UserDTO>();
            List<User> users = new List<User>();
            users = await _dbContext.Users.ToListAsync<User>();

            foreach (User user in users)
            {
                usersDtos.Add(new UserDTO
                {
                    UserId = user.UserId,
                    UserDni = user.UserDni,
                    UserName = user.UserName,
                    UserLastName = user.UserLastName,
                    UserBirthdate = user.UserBirthdate,
                    UserEmail = user.UserEmail,    
                    UserAddress = user.UserAddress,
                    UserCellphone = user.UserCellphone,
                    UserCity = user.UserCity,
                    UserCountry = user.UserCountry,
                    UserRegisterDate = user.UserRegisterDate,
                    UserRole = user.UserRole,
                    ProfileImageName = user.ProfileImageName,
                });
            }

            return usersDtos;
        }
    }
}
