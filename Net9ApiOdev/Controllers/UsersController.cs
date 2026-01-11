using Microsoft.AspNetCore.Mvc;
using Net9ApiOdev.DTOs;
using Net9ApiOdev.Services;

namespace Net9ApiOdev.Controllers
{
    [Route("api/[controller]")] 
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        
        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<UserResponseDto>>>> GetAllUsers()
        {
            var result = await _userService.GetAllUsers();
            return Ok(result); 
        }

        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<UserResponseDto>>> CreateUser(CreateUserDto request)
        {
            var result = await _userService.CreateUser(request);
            return Ok(result);
        }
    }
}