namespace Net9ApiOdev.Entities
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; } 
        public User User { get; set; }

        public int ProductId { get; set; } 
        public Product Product { get; set; }
    }
}