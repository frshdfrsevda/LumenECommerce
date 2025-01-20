using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users
{
    public class UserNewPasswordVM
    {
        [DataType(DataType.Password)]
        [Display(Name = "Mevcut Şifre")]
        [Required(ErrorMessage ="Mevcut şifrenizi girmelisiniz.")]
        public string CurrentPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        [Required(ErrorMessage = "Yeni şifrenizi girmelisiniz.")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(NewPassword), ErrorMessage = "Şifreler uyuşmadı.")]
        [Display(Name = "Yeni Şifre Tekrar")]
        [Required(ErrorMessage = "Yeni şifrenizi tekrar girmelisiniz.")]
        public string ConfirmNewPassword { get; set; }
    }
}
