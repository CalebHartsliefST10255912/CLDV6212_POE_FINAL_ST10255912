using ABC_Retail_ST10255912_POE.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ABC_Retail_ST10255912_POE.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Products> Products { get; set; } = default!;
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Order { get; set; } = default!;
        public DbSet<Category> Categories { get; set; } = default!; // Add Categories DbSet

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships for CartItem
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Products)
                .WithMany()
                .HasForeignKey(ci => ci.ProductID)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data for Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "1950s" },
                new Category { CategoryID = 2, CategoryName = "1960s" },
                new Category { CategoryID = 3, CategoryName = "1970s" },
                new Category { CategoryID = 4, CategoryName = "1980s" }
            );
        }
    }
}
