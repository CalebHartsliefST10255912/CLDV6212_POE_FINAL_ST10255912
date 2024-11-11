using System;
using System.Linq;
using System.Threading.Tasks;
using ABC_Retail_ST10255912_POE.Data;
using ABC_Retail_ST10255912_POE.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ABC_Retail_ST10255912_POE
{
    public static class CategoryInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                await context.Database.MigrateAsync();

                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Categories { CategoryID = 1, CategoryName = "1950's" },
                        new Categories { CategoryID = 2, CategoryName = "1960's" },
                        new Categories { CategoryID = 3, CategoryName = "1970's" },
                        new Categories { CategoryID = 4, CategoryName = "1980's" }
                    );
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
