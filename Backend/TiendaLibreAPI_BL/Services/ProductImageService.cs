using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class ProductImageService : IProductImageService
    {
        private readonly DatabaseContext _dbContext;
        private readonly string _imagePath;
        private readonly IImageFileManagerService _imageFileManagerService;

        public ProductImageService(DatabaseContext dbContext, IImageFileManagerService imageFileManagerService)
        {
            _dbContext = dbContext;
            _imagePath = "Assets\\Images\\Product_images";
            _imageFileManagerService = imageFileManagerService;
        }



        public async Task<string> AddProductImages(ICollection<IFormFile> imageFiles, long productId)
        {
            Product? product = await _dbContext.Products.
                FirstOrDefaultAsync(product => product.ProductId == productId);
            if (product == null) throw new Exception("Product not found");

            //Saving product images
            ICollection<ProductImage> productImages = new List<ProductImage>();
            foreach(IFormFile file in imageFiles)
            {
                string imageFileName = _imageFileManagerService.SaveImageFile(file, _imagePath);
                if (imageFileName.Length == 0) throw new Exception("Error saving image");

                productImages.Add(new ProductImage
                {
                    ProductImageName = imageFileName,
                    Product = product
                });
            }
            

            await _dbContext.ProductImages.AddRangeAsync(productImages);
            await _dbContext.SaveChangesAsync();
            await _dbContext.DisposeAsync();

            return $"Images saved";
        }

        public async Task<ICollection<ProductImageDTO>> GetProductImages(long productId)
        {
            ICollection<ProductImage> productImages = await _dbContext.ProductImages.
                Where(productImage => productImage.Product.ProductId == productId).ToListAsync();

            ICollection<ProductImageDTO> productImagesDto = new List<ProductImageDTO>();

            foreach (ProductImage productImage in productImages)
            {
                productImagesDto.Add(new ProductImageDTO
                {
                    ProductImageId = productImage.ProductImageId,
                    ProductImageName = productImage.ProductImageName,
                    DataImage = File.ReadAllBytes(Path.Combine(_imagePath, productImage.ProductImageName))

                });
            }

            return productImagesDto.ToList();
        }

        /*public async Task<ICollection<Byte[]>> GetProductImages(long productId)
        {
            ICollection<ProductImage> productImages = await _dbContext.ProductImages.ToListAsync();
            ICollection<Byte[]> images = new List<Byte[]>();

            foreach(ProductImage image in productImages)
            {
                Byte[] bytesImage = File.ReadAllBytes(Path.Combine(_imagePath, image.ProductImageName));
                images.Add(bytesImage);
            }

            return images.ToList();
        }*/
    }
}
