using System.ComponentModel.DataAnnotations;

namespace ShopMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "������")]
        public string Password { get; set; }

        [Display(Name = "���������?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
