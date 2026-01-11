using Microsoft.EntityFrameworkCore;
using Net9ApiOdev.Data;
using Net9ApiOdev.DTOs;
using Net9ApiOdev.Entities;

namespace Net9ApiOdev.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<UserResponseDto>> CreateUser(CreateUserDto request)
        {
            var response = new ServiceResponse<UserResponseDto>();

           
            var newUser = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password 
            };

            
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            
            response.Data = new UserResponseDto
            {
                Id = newUser.Id,
                Name = newUser.Name,
                Email = newUser.Email,
                Role = newUser.Role
            };
            response.Message = "Kullanıcı başarıyla oluşturuldu.";

            return response;
        }

        public async Task<ServiceResponse<List<UserResponseDto>>> GetAllUsers()
        {
            var response = new ServiceResponse<List<UserResponseDto>>();

            
            var users = await _context.Users
                .Select(u => new UserResponseDto
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    Role = u.Role
                }).ToListAsync();

            response.Data = users;
            return response;
        }
    }
}