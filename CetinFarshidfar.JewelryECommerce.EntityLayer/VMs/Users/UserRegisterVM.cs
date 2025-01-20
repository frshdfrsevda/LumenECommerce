using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users
{
    public class UserRegisterVM
    {
        [StringLength(150, MinimumLength = 6, ErrorMessage = "İsim Soyisim en az 6, en çok 150 karakterden oluşabilir.")]
        [Display(Name = "İsim Soyisim")]
        public string FullName { get; set; }
        [EmailAddress(ErrorMessage = "Email adresinizi doğru formatta girmediniz.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefon No")]
        [Phone (ErrorMessage = "Telefon numaranızı doğru giriniz.")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.Password)]
        [Required (ErrorMessage = "Şifrenizi giriniz")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage = "Şifreniz doğrulanamadı.")]
        [Display(Name = "Şifreni Doğrula")]
        public string ConfirmPassword { get; set; }
    }
}
