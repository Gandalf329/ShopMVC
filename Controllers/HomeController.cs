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
using Microsoft.AspNetCore.Http;
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
            string description1 = "Функциональный и стильный смартфон Apple iPhone 11 в металлическом корпусе способен обеспечить не только повседневное общение и развлечения, но и продуктивную работу. Для этого он оснащен мощным процессором Apple A13 Bionic из 6 ядер, поддерживающим слаженную работу всех комплектующих, а также модулем ОЗУ объемом в 4 ГБ, что предусматривает быстрое переключение между открытыми приложениями и возможность играть в игры.";
            string description2 = "Apple iPhone 12 — ультрамощный смартфон от престижного бренда. Девайс получил молниеносный процессор A14 Bionic и впечатляющий дисплей Super Retina XDR от края до края. Набор продвинутых камер эффективно работает даже в условиях слабого освещения. Видеоролики Dolby Vision завораживают реалистичностью. Фотовозможности гаджета колоссальны. Широкоугольный датчик теперь улавливает значительно больше света.";
            string description3 = "iPhone 13 работает от аккумулятора до 2,5 часов дольше. Процессор A15 Bionic и камера TrueDepth также обеспечивают работу Face ID, невероятно надёжной технологии аутентификации. Сверхбыстрый чип A15 Bionic обеспечивает работу режима «Киноэффект», фотографических стилей и других функций. Secure Enclave защищает персональные данные, в том числе Face ID и контакты. А ещё новый чип увеличивает время работы от аккумулятора.";
            string description4 = "Full HD (1920x1080), IPS, AMD Ryzen 9 5900HX, ядра: 8 х 3.3 ГГц, RAM 32 ГБ, SSD 1000 ГБ, GeForce RTX 3070 для ноутбуков 8 ГБ, Windows 10 Home";
            string description5 = "Молниеносная скорость загрузки благодаря сверхскоростному накопителю SSD, невероятный эффект погружения благодаря тактильной отдаче, адаптивным спусковым кнопкам и 3D-звуку, а также потрясающие игры нового поколения для PlayStation.Невероятно мощные центральный и графический процессоры, а также SSD-диск с интегрированной системой ввода-вывода перевернут ваше представление о возможностях консоли PlayStation.Беспроводной контроллер DualSense™ для PS5 предлагает игрокам тактильную отдачу, дополняющую спектр ощущений от игры, адаптивные спусковые курки и встроенный микрофон – все эти функции прекрасно дополняют новый узнаваемый дизайн.";
            string description6 = "Xbox Series X — консоль нового поколения, которая обеспечивает сенсационно плавную частоту до 120 к/с и яркую и контрастную HDR-картинку. Погрузитесь в игру с головой, наслаждаясь более чёткими персонажами, яркими мирами и невероятными деталями в сверхреалистичном качестве 4K.";
            int[] price =  new int[] { 1000,1100,1300,1500,1400,1200};
            string[] company = new string[] { "Apple","Asus","Sony", "Microsoft"};
            string[] type = new string[] { "Phone","Laptop", "Console","Xbox"};
            string[] category1 = new string[] { "Phone","Computer","VideoGames"};
            string[] category2 = new string[] { "SmartPhone", "Laptop","PlayStation","Xbox"};
            
            if (db.Products.Count() == 0)
            {
                
                Product product1 = new Product { Name = "Iphone 11", Category1 = category1[0], Category2 = category2[0], Company = company[0], Type = type[0], Amount = 23, Description = description1, Price = price[0] };
                Product product2 = new Product { Name = "Iphone 12", Category1 = category1[0], Category2 = category2[0], Company = company[0], Type = type[0], Amount = 25, Description = description2, Price = price[1] };
                Product product3 = new Product { Name = "Iphone 13", Category1 = category1[0], Category2 = category2[0], Company = company[0], Type = type[0], Amount = 22, Description = description3, Price = price[2] };
                Product product4 = new Product { Name = "ASUS ROG Strix Scar 15", Category1 = category1[1], Category2 = category2[1], Company = company[1], Type = type[1], Amount = 12, Description = description4, Price = price[3] };
                Product product5 = new Product { Name = "PlayStation 5", Category1 = category1[2], Category2 = category2[2], Company = company[2], Type = type[2], Amount = 7, Description = description5, Price = price[4] };
                Product product6 = new Product { Name = "Xbox Series X", Category1 = category1[2], Category2 = category2[3], Company = company[3], Type = type[2], Amount = 10, Description = description6, Price = price[5] };
                db.Products.AddRange(product1, product2, product3, product4, product5, product6);
                db.SaveChanges();
            }
            if (db.OrderModels.Count() == 0)
            {
                OrderModel model1 = new OrderModel { NameBuyer = "Nikita", NameProduct = "Iphone 11", Address = "Spb", TypeProduct = type[0], Price = price[0], CompanyProduct = company[0] };
                OrderModel model2 = new OrderModel { NameBuyer = "Nikita", NameProduct = "Iphone 12", Address = "Che", TypeProduct = type[0], Price = price[1], CompanyProduct = company[0] };
                OrderModel model3 = new OrderModel { NameBuyer = "Michael", NameProduct = "Iphone 13", Address = "Msc", TypeProduct = type[0], Price = price[2], CompanyProduct = company[0] };
                OrderModel model4 = new OrderModel { NameBuyer = "Lebron", NameProduct = "PlayStation 5", Address = "Msc", TypeProduct = type[2], Price = price[4], CompanyProduct = company[2] };
                db.OrderModels.AddRange(model1, model2, model3, model4);
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
        public async Task<IActionResult> CreateProduct(ProductViewModel product)
        {   
            Product productNew = new Product();
            byte[] imageData = null;
            if (product.Photo != null)
            {
                 using (var binaryReader = new BinaryReader(product.Photo.OpenReadStream()))
                 {
                    imageData = binaryReader.ReadBytes((int)product.Photo.Length);
                }              
            }
            productNew.Photo=imageData;
            productNew.Name = product.Name;
            productNew.Type = product.Type;
            productNew.Description = product.Description;
            productNew.Category1 = product.Category1;
            productNew.Category2 = product.Category2;
            productNew.Company  = product.Company;
            productNew.Amount = product.Amount;
            productNew.Price  = product.Price;
            db.Products.Add(productNew);
            await db.SaveChangesAsync();
            return RedirectToAction("AllProducts");
        }
       
        [Authorize(Roles = "admin")]
        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                {
                    db.Products.Remove(product);
                    await db.SaveChangesAsync();
                    return RedirectToAction("AllProducts");
                }
            }
            return NotFound();
        }
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> EditProduct(int? id)
        {
            if(id!=null)
            {
                Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == id);
                if (product != null)
                    return View(product);
            }
            return RedirectToAction("AllProducts");
        }
        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> EditProduct(ProductViewModel productVM)
        {
            Product product = await db.Products.FirstOrDefaultAsync(p => p.Id == productVM.Id);

            byte[] imageData = null;
            if (productVM.Photo != null)
            {
                 using (var binaryReader = new BinaryReader(productVM.Photo.OpenReadStream()))
                 {
                    imageData = binaryReader.ReadBytes((int)productVM.Photo.Length);
                }              
            }
            product.Photo=imageData;
            db.Products.Update(product);
            await db.SaveChangesAsync();
            return RedirectToAction("AllProducts");
        }
        public IActionResult ProductView(int id)
        {
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
