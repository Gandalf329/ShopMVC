using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ShopMVC.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public string Name { get; set; }
    }
}
