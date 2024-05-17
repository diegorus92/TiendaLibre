using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiendaLibreAPI_BL.Services
{
    public class ImageFileManagerService : IImageFileManagerService
    {
        
        /*string argument is only the directory path without ignoring all the previous directories
        where the project is allocate in Directoy Explorer*/
        public string SaveImageFile(IFormFile file, string relativePathStorageFile)
        {
            if (Path.GetExtension(file.FileName).ToLower() != ".jpg" && Path.GetExtension(file.FileName).ToLower() != ".png")
                return string.Empty;

            string randomFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string pathFile = Path.Combine(Directory.GetCurrentDirectory(), relativePathStorageFile);

            if(!Directory.Exists(pathFile)) 
                Directory.CreateDirectory(pathFile);

            string completeNewPathFile = Path.Combine(Directory.GetCurrentDirectory(), relativePathStorageFile, randomFileName);

            using (var stream = File.Create(completeNewPathFile))
            {
                file.CopyTo(stream);
            }

            return randomFileName;
        }
    }
}
