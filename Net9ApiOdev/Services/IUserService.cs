using Net9ApiOdev.DTOs;
using Net9ApiOdev.Entities;

namespace Net9ApiOdev.Services
{
    public interface IUserService
    {
       
        Task<ServiceResponse<List<UserResponseDto>>> GetAllUsers();

        
        Task<ServiceResponse<UserResponseDto>> CreateUser(CreateUserDto request);
    }
}