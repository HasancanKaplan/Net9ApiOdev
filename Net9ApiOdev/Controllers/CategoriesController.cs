using Microsoft.AspNetCore.Mvc;
using Net9ApiOdev.DTOs;
using Net9ApiOdev.Services;

namespace Net9ApiOdev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CategoryResponseDto>>>> GetAll()
        {
            return Ok(await _categoryService.GetAllCategories());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<CategoryResponseDto>>> Create(CreateCategoryDto request)
        {
            return Ok(await _categoryService.CreateCategory(request));
        }
    }
}