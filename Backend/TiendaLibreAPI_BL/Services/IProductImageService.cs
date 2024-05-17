using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiendaLibreAPI_BL.DTOs;
using TiendaLibreAPI_DAL.Models;

namespace TiendaLibreAPI_BL.Services
{
    public interface IProductImageService
    {
        public Task<string> AddProductImages(ICollection<IFormFile> imageFiles, long productId);
        public Task<ICollection<ProductImageDTO>> GetProductImages(long productId);
    }
}
