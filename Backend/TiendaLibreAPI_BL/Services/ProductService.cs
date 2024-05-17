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
    public class ProductService : IProductService
    {
        private readonly DatabaseContext _dbContext;

        public ProductService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task AddProduct(ProductPostDTO productPostDto)
        {
            User? userSeller = await _dbContext.Users.FirstOrDefaultAsync(user => user.UserId == productPostDto.UserSellerId);
            if (userSeller == null) throw new Exception("User not found");

            Product product = new Product
            {
                ProductName = productPostDto.ProductName,
                ProductCategory = productPostDto.ProductCategory,
                ProductBrand = productPostDto.ProductBrand,
                ProductModel = productPostDto.ProductModel,
                Price = productPostDto.Price,
                StockQty = productPostDto.StockQty,
                ProductUserSeller = userSeller
            };

            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            await _dbContext.DisposeAsync();
        }

        public async Task<ICollection<ProductDTO>> GetProducts()
        {
            List<ProductDTO> productsDtos = new List<ProductDTO>();
            List<Product> products = await _dbContext.Products.Include(product => product.ProductUserSeller).ToListAsync();

            foreach(Product product in products)
            {
                productsDtos.Add(new ProductDTO
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    ProductCategory = product.ProductCategory,
                    ProductBrand = product.ProductBrand,
                    ProductModel = product.ProductModel,
                    Price = product.Price,
                    StockQty = product.StockQty,
                    UserSellerId = product.ProductUserSeller.UserId
                });
            }

            return productsDtos;
        }

        public async Task UpdateProduct(long productId, ProductUpdateDTO productUpdateDto)
        {
            Product? productToUpdate = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (productToUpdate == null) throw new Exception("Product not found");

            productToUpdate.ProductName = productUpdateDto.ProductName;
            productToUpdate.ProductModel = productUpdateDto.ProductModel;
            productToUpdate.ProductBrand = productUpdateDto.ProductBrand;
            productToUpdate.ProductCategory = productUpdateDto.ProductCategory;
            productToUpdate.Price = productUpdateDto.Price;
            productToUpdate.StockQty = productUpdateDto.StockQty;
            
            _dbContext.Products.Update(productToUpdate);
            await _dbContext.SaveChangesAsync();
            await _dbContext.DisposeAsync();
        }
    }
}
