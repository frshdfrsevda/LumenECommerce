using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users
{
    public class UserLoginVM
    {
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Doğru ve uygun formatta email adresi giriniz.")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Şifrenizi giriniz.")]
        public string Password { get; set; }
    }
}
