using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShopMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMVC.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationContext db;
        public OrderController(ApplicationContext context)
        {
            db = context;
            if (db.OrderModels.Count() == 0)
            {
                OrderModel model1 = new OrderModel { NameBuyer = "Nikita", NameProduct = "Iphone 11", Address = "Spb", TypeProduct = "Phone", Price = 3, CompanyProduct = "Apple"};
                OrderModel model2 = new OrderModel { NameBuyer = "Nikita", NameProduct = "Iphone 12", Address = "Che", TypeProduct = "Phone", Price = 5, CompanyProduct = "Apple"};
                OrderModel model3 = new OrderModel { NameBuyer = "Nikita", NameProduct = "Iphone 13", Address = "Msc", TypeProduct = "Phone", Price = 2, CompanyProduct = "Apple"};
                
                db.OrderModels.AddRange(model1, model2, model3);
                db.SaveChanges();
            }
        }
        public IActionResult BuyProduct()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> BuyProduct(OrderModel orderModel)
        {
            db.OrderModels.Add(orderModel);
            //Console.Beep();
            await db.SaveChangesAsync();
            return RedirectToAction("AllProducts");
        }
    }
}
