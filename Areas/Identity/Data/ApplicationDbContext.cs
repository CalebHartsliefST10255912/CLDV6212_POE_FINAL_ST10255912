using ABC_Retail_ST10255912_POE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ABC_Retail_ST10255912_POE.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    // DbSets for entities
    public DbSet<Customers> Customers { get; set; }
    public DbSet<Products> Products { get; set; }
    public DbSet<Orders> Orders { get; set; }
    public DbSet<Carts> Carts { get; set; }
    public DbSet<CartItems> CartItems { get; set; }
    public DbSet<Categories> Categories { get; set; }

}
