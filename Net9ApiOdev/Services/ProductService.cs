using Microsoft.EntityFrameworkCore;
using Net9ApiOdev.Data;
using Net9ApiOdev.DTOs;
using Net9ApiOdev.Entities;

namespace Net9ApiOdev.Services
{
    public interface IProductService
    {
        Task<ServiceResponse<List<ProductResponseDto>>> GetAllProducts();
        Task<ServiceResponse<ProductResponseDto>> CreateProduct(CreateProductDto request);
    }

    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<ProductResponseDto>> CreateProduct(CreateProductDto request)
        {
         
            var product = new Product
            {
                Name = request.Name,
                Price = request.Price,
                Stock = request.Stock,
                CategoryId = request.CategoryId 
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return new ServiceResponse<ProductResponseDto>
            {
                Data = new ProductResponseDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock,
                    CategoryName = "Yeni Eklendi" 
                },
                Message = "Ürün başarıyla eklendi."
            };
        }

        public async Task<ServiceResponse<List<ProductResponseDto>>> GetAllProducts()
        {
            
            var products = await _context.Products
                .Include(p => p.Category)
                .Select(p => new ProductResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Stock = p.Stock,
                    CategoryName = p.Category.Name 
                }).ToListAsync();

            return new ServiceResponse<List<ProductResponseDto>> { Data = products };
        }
    }
}