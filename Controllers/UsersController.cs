using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShopMVC.ViewModels;
using ShopMVC.Models;
using Microsoft.AspNetCore.Authorization;
using ShopMVC.Filters;
using System.IO;
using System;

namespace ShopMVC.Controllers
{
    public class UsersController : Controller
    {
        UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        //[Authorize(Roles = "admin")]
        //public IActionResult Index() => View(_userManager.Users.ToList());
        //[Authorize(Roles = "admin")]
        //public IActionResult Create() => View();
        
        
        public async Task<IActionResult> ViewUserProfile(string name)
        {
            User user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }
            ViewUserProfileModel model = new ViewUserProfileModel { Id = user.Id, UserName = user.UserName, Email = user.Email, Money = user.Money, Year = user.Year };
            return View(model);
        }


    }
}
