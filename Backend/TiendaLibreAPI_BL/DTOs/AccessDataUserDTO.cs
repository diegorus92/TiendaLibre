﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibreAPI_BL.DTOs
{
    public class AccessDataUserDTO
    {
        public long UserId { get; set; }
        public string UserEmail { get; set; }
        public string? Token { get; set; }
    }
}
