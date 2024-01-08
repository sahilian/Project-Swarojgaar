using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Swarojgaar.Data;


namespace Swarojgaar.Models
{
    public static class IdentitySeedData
    {

        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<ApplicationDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            RoleManager<IdentityRole> roleManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<UserManager<IdentityUser>>();

            string roleName = "Admin";

            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            IdentityUser user = await userManager.FindByNameAsync(adminUser);

            if (user == null)
            {
                user = new IdentityUser("admin@gmail.com");
                user.EmailConfirmed = true;
                user.Email = "admin@gmail.com";
                user.PhoneNumber = "9840030129";
                
                await userManager.CreateAsync(user, adminPassword);

                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
