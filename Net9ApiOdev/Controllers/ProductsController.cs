using Microsoft.AspNetCore.Mvc;
using Net9ApiOdev.DTOs;
using Net9ApiOdev.Services;

namespace Net9ApiOdev.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<ProductResponseDto>>>> GetAll()
        {
            return Ok(await _productService.GetAllProducts());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<ProductResponseDto>>> Create(CreateProductDto request)
        {
            return Ok(await _productService.CreateProduct(request));
        }
    }
}