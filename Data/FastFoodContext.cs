using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplicationCourseWork.Models;



namespace WebApplicationCourseWork.Data
{
    public class FastFoodContext : IdentityDbContext<IdentityUser>
    {
        public FastFoodContext (DbContextOptions<FastFoodContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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