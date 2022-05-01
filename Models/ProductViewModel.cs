using Microsoft.AspNetCore.Http;

namespace ShopMVC.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Category1 { get; set; }
        public string Category2 { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Company { get; set; }
        public string Description { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public IFormFile Photo { get; set; }
    }
}
