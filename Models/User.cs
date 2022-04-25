using Microsoft.AspNetCore.Identity;

namespace ShopMVC.Models
{
    public class User : IdentityUser
    {
        //public string UserName { get; set; }
        public int Year { get; set; }
        public int Money { get; set; }
    }
}
