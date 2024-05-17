using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibreAPI_BL.DTOs
{
    public class UserDTO
    {
        public long UserId { get; set; }
        public string UserDni { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public DateOnly UserBirthdate { get; set; }
        public string UserEmail { get; set; }
        public string UserCellphone { get; set; }
        public string UserAddress { get; set; }
        public string UserCountry { get; set; }
        public string UserCity { get; set; }
        public DateTime UserRegisterDate { get; set; }
        public string UserRole { get; set; }
        public string? ProfileImageName { get; set; }
    }
}
