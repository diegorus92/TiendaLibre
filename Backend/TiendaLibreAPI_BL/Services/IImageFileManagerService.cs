using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibreAPI_BL.Services
{
    public interface IImageFileManagerService
    {
        public string SaveImageFile(IFormFile file, string relativePathStorageFile);
    }
}
