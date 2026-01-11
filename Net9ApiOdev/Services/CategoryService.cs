using Microsoft.EntityFrameworkCore;
using Net9ApiOdev.Data;
using Net9ApiOdev.DTOs;
using Net9ApiOdev.Entities;

namespace Net9ApiOdev.Services
{
    
    public interface ICategoryService
    {
        Task<ServiceResponse<List<CategoryResponseDto>>> GetAllCategories();
        Task<ServiceResponse<CategoryResponseDto>> CreateCategory(CreateCategoryDto request);
    }

    
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<CategoryResponseDto>> CreateCategory(CreateCategoryDto request)
        {
            var category = new Category { Name = request.Name };
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return new ServiceResponse<CategoryResponseDto>
            {
                Data = new CategoryResponseDto { Id = category.Id, Name = category.Name },
                Message = "Kategori başarıyla eklendi."
            };
        }

        public async Task<ServiceResponse<List<CategoryResponseDto>>> GetAllCategories()
        {
            var categories = await _context.Categories
                .Select(c => new CategoryResponseDto { Id = c.Id, Name = c.Name })
                .ToListAsync();

            return new ServiceResponse<List<CategoryResponseDto>> { Data = categories };
        }
    }
}