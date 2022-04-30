using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ShopMVC.Filters;
using Microsoft.AspNetCore.Authorization;
using System.IO;

namespace ShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationContext db;
        UserManager<User> _userManager;
        public HomeController(UserManager<User> userManager, ApplicationContext context)
        {
            _userManager = userManager;
            db = context;
            if (db.Products.Count() == 0)
            {
                Product message1 = new Product { Name = "Iphone 11", Category1 = "Phone", Category2 = "SmartPhone", Company = "Apple", Type = "Phone", Amount = 23, Description = "123", Price = 1000 };
                Product message2 = new Product { Name = "Iphone 12", Category1 = "Phone", Category2 = "SmartPhone", Company = "Apple", Type = "Phone", Amount = 25, Description = "456", Price = 1100 };
                Product message3 = new Product { Name = "Iphone 13", Category1 = "Phone", Category2 = "SmartPhone", Company = "Apple", Type = "Phone", Amount = 22, Description = "789", Price = 1300 };
                Product message4 = new Product { Name = "ASUS ROG Strix Scar 15", Category1 = "Computer", Category2 = "Laptop", Company = "Asus", Type = "Laptop", Amount = 12, Description = "789", Price = 1500 };
                Product message5 = new Product { Name = "PlayStation 5", Category1 = "VideoGames", Category2 = "PlayStation", Company = "PlayStation", Type = "Console", Amount = 7, Description = "789", Price = 1400 };
                Product message6 = new Product { Name = "Xbox Series X", Category1 = "VideoGames", Category2 = "Xbox", Company = "Xbox", Type = "Console", Amount = 10, Description = "789", Price = 1200 };
                db.Products.AddRange(message1, message2, message3, message4, message5, message6);
                db.SaveChanges();
            }
            if (db.OrderModels.Count() == 0)
            {
                OrderModel model1 = new OrderModel { NameBuyer = "Nikita", NameProduct = "Iphone 11", Address = "Spb", TypeProduct = "Phone", Price = 3, CompanyProduct = "Apple" };
                OrderModel model2 = new OrderModel { NameBuyer = "Nikita", NameProduct = "Iphone 12", Address = "Che", TypeProduct = "Phone", Price = 5, CompanyProduct = "Apple" };
                OrderModel model3 = new OrderModel { NameBuyer = "Nikita", NameProduct = "Iphone 13", Address = "Msc", TypeProduct = "Phone", Price = 2, CompanyProduct = "Apple" };

                db.OrderModels.AddRange(model1, model2, model3);
                db.SaveChanges();
            }
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public async Task<IActionResult> AllProducts(string searchString)
        {
            var products = from m in db.Products
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.Contains(searchString));
                //string check = products.ToString();
            }

            return View(await products.ToListAsync());
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
            return RedirectToAction("AllProducts");
        }
        public IActionResult ProductView(int id)
        {
            Console.WriteLine(id);
            //var thisproducts = db.Products.Where(p => p.Name == name);
            //foreach (Product prod in thisproducts)
            //{
            //    Console.WriteLine($"{prod.Name} ({prod.Amount})");
            //}
            Console.WriteLine(db.Products.Find(id));
            return View(db.Products.Find(id));
        }
        [HttpPost]
        public async Task<IActionResult> BuyTest(int id)
        {
            db.Products.Find(id).Amount -= 1;
            await db.SaveChangesAsync();
            return RedirectToAction("AllProducts");
        }
        public IActionResult BuyProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BuyProduct(OrderModel orderModel)
        {
            Product prod = db.Products.FirstOrDefault(p => p.Name == orderModel.NameProduct);
            if (prod != null)
            {
                Console.WriteLine($"{prod.Id} : its Id");
                Console.WriteLine($"{prod.Amount} : its Amount");
                db.Products.Find(prod.Id).Amount -= 1;
                orderModel.CompanyProduct = prod.Company;
                orderModel.Price = prod.Price;
                orderModel.TypeProduct = prod.Category2;
                await db.SaveChangesAsync();
            }
            User user = await _userManager.FindByNameAsync(orderModel.NameBuyer);
            if (user != null)
            {
                user.Money -= prod.Price;
                await db.SaveChangesAsync();
            }    
            db.OrderModels.Add(orderModel);

            await db.SaveChangesAsync();
            return RedirectToAction("AllProducts");
        }
        public async Task<IActionResult> AllCategories()
        {
            var products = (from m in db.Products
                           select m).Distinct();
            
            return View(await products.ToListAsync());
        }
        public async Task<IActionResult> Categories(string nameCategory)
        {
            Console.WriteLine($"Category : {nameCategory}");

            var products = from m in db.Products
                           select m;

            if (!String.IsNullOrEmpty(nameCategory))
            {
                products = products.Where(p => p.Category2.Contains(nameCategory));
                //string check = products.ToString();
            }
            return View(await products.ToListAsync());
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AllOrders()
        {
            var orders = (from m in db.OrderModels
                           select m);
            
            return View(await orders.ToListAsync());
        }
        public async Task<IActionResult> MyOrders(string name)
        {
            var orders = (from m in db.OrderModels
                           select m);
            if (!String.IsNullOrEmpty(name))
            {
                orders = orders.Where(p => p.NameBuyer.Contains(name));
                //string check = products.ToString();
            }
            return View(await orders.ToListAsync());
        }
    }
}
