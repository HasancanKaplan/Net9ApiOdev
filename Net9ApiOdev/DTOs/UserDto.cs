namespace Net9ApiOdev.DTOs
{
    
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    
    public class UserResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }

    
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}