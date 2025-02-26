using Microsoft.EntityFrameworkCore;
using WebAplicationCourseWork.Models;

namespace WebAplicationCourseWork.Models
{
    public class FastFoodContext : DbContext
    {
        public FastFoodContext (DbContextOptions<FastFoodContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             modelBuilder.Entity<OrderItem>()
                .HasKey(c => new {c.OrderID, c.ItemID}); // Fluent Api to allow for the creation of a composite key
        }
        public DbSet<Order> Orders {get; set;}
        public DbSet<Item> Items {get; set;}
        public DbSet<OrderItem> OrderItems {get; set;}
        public DbSet<Customer> Customer { get; set; } 
        public DbSet<Staff> Staff { get; set; } 
        
    }
}