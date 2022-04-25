using Microsoft.AspNetCore.Http;

namespace ShopMVC.ViewModels
{
    public class ViewUserProfileModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public int Year { get; set; }
        public int Money { get; set; }
        public string Email { get; set; }
        
    }
}
