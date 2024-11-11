using Microsoft.AspNetCore.Identity;

namespace ABC_Retail_ST10255912_POE
{
    public static class RoleInitializer
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

                // Ensure 'Admin' role exists
                if (!await roleManager.RoleExistsAsync("Admin"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Admin"));
                }

                if (!await roleManager.RoleExistsAsync("Customer"))
                {
                    await roleManager.CreateAsync(new IdentityRole("Customer"));
                }

                // Check and create an admin user
                var user = await userManager.FindByEmailAsync("admin@support.com");
                if (user == null)
                {
                    user = new IdentityUser
                    {
                        UserName = "admin@support.com",
                        Email = "admin@support.com",
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(user, "Admin@123"); // Ensure secure password in production
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, "Admin");
                    }
                }
            }
        }
    }
}
