using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using ShopMVC.Models;


namespace ShopMVC
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminName = "AdminNik";
            string adminEmail = "admin@gmail.com";
            string userEmail = "pohlebaev.n@yandex.ru";
            string userEmail1 = "james@king.com";
            string userEmail2 = "michael@gmail.com";
            string userName1 = "Nikita";
            string userName2 = "Lebron";
            string userName3 = "Michael";

            int adminYear = 2002;
            string password = "nikita1";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await userManager.FindByNameAsync(adminEmail) == null && await userManager.FindByNameAsync(userName1) == null && await userManager.FindByNameAsync(userName2) == null
                && await userManager.FindByNameAsync(userName3) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminName, Year = adminYear, Money = 1000050000 };
                User user = new User { Email = userEmail, UserName = userName1, Year = 2002, Money = 100500 };
                User user1 = new User { Email = userEmail1, UserName = userName2, Year = 2002, Money = 100500 };
                User user2 = new User { Email = userEmail2, UserName = userName3, Year = 1978, Money = 100500 };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                IdentityResult result1 = await userManager.CreateAsync(user, "12345");
                IdentityResult result2 = await userManager.CreateAsync(user1, "12345");
                IdentityResult result3 = await userManager.CreateAsync(user2, "12345");
                if (result.Succeeded & result1.Succeeded & result2.Succeeded & result3.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                    await userManager.AddToRoleAsync(user1, "user");
                    await userManager.AddToRoleAsync(user2, "user");
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}
