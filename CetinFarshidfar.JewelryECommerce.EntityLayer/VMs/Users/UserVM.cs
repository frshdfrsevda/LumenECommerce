using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users
{
    public class UserVM
    {
        [Required(ErrorMessage ="Id bilgisi alınamadı.")]
        [Display(Name ="Kullanıcı ID")]
        public Guid Id { get; set; }
        [Display(Name = "İsim Soyisim")]
        [Required(ErrorMessage = "İsim Soyisim boş bırakılamaz.")]
        public string FullName { get; set; }
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "Telefon Numarası boş bırakılamaz.")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Email Durumu")]
        public bool EmailConfirmed { get; set; }
        public int AccessFailedCount { get; set; }
        [Display(Name = "Yetki")]
        public string Role { get; set; }
        [Display(Name = "Oluşturulma Tarihi")]
        public DateTime? CreatedTime { get; set; }
    }
}
