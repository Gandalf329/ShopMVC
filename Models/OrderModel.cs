namespace ShopMVC.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public string NameBuyer { get; set; }
        public string NameProduct { get; set; }
        public string Address { get; set; }
        public string TypeProduct { get; set; }
        public string CompanyProduct { get; set; }
        public int Price { get; set; }
        
    }
}
