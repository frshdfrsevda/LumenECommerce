using CetinFarshidfar.JewelryECommerce.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites
{
    public class CompanyApplication : IEntityBase
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString("N").Substring(0, 12);
        [Display(Name = "Firma İsmi")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Firma isminizi giriniz.")]
        public string ComName { get; set; }
        [Display(Name = "Yönetici İsim Soyisim")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "İsim Soyisim giriniz.")]
        public string ManagerFullName { get; set; }
        [Display(Name = "Yönetici Email")]
        [EmailAddress(ErrorMessage = "Email adresinizi doğru ve uygun formatta giriniz.")]
        public string ManagerEmail { get; set; }
        [Display(Name = "Yönetici Telefon No")]
        [Phone]
        [Required(ErrorMessage = "Telefon numarası doğru ve uygun formatta giriniz.")]
        public string ManagerPhone { get; set; }
        public bool Status { get; set; } = false;
        public DateTime CreatedTime { get; set; } =DateTime.Now;
    }
}
