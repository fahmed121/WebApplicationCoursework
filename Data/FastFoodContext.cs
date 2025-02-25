using Microsoft.EntityFrameworkCore;

namespace WebAplicationCourseWork.Models
{
    public class FastFoodContext : DbContext
    {
        public FastFoodContext (DbContextOptions<FastFoodContext> options) : base(options)
        {}
        public DbSet<Order> Orders {get; set;}
        public DbSet<Item> Items {get; set;}
        public DbSet<OrderItem> OrderItems {get; set;}
        
    }
}