using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users
{
    public class UserProfileVM
    {
        [Display(Name ="İsim Soyisim")]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Şifreniz*")]
        public string CurrentPassword { get; set; }
        [Display(Name = "Yeni Şifre (Opsiyonel)")]
        public string? NewPassword { get; set; }
    }
}
