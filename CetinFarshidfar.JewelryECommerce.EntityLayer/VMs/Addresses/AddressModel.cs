using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Addresses
{
    public class AddressModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="Adresiniz için bir başlık belirleyin.")]
        [Display(Name ="Adres Başlığı")]
        public string Title { get; set; }
        [Required(ErrorMessage = "İsim - Soyisim girmelisiniz.")]
        [Display(Name = "İsim - Soyisim")]
        public string CustomerFullName { get; set; }
        [Phone]
        [Required(ErrorMessage = "Telefon numaranızı girmelisiniz.")]
        [Display(Name = "Telefon Numaranız")]
        public string CustomerPhone { get; set; }
        [Required(ErrorMessage = "Şehir bilgisi girmelisiniz.")]
        [Display(Name = "Şehir")]
        public string City { get; set; }
        [Required(ErrorMessage = "İlçe bilgisi girmelisiniz.")]
        [Display(Name = "İlçe")]
        public string District { get; set; }
        [Required(ErrorMessage = "Sokak bilgisi girmelisiniz.")]
        [Display(Name = "Mahalle- Sokak - Cadde")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Adres detay bilgisi girmelisiniz.")]
        [Display(Name = "Adres Detay - Tarif")]
        public string Detail { get; set; }
        [Required(ErrorMessage = "Şehir posta kodunuzu girmelisiniz.")]
        [Display(Name = "Posta Kodu")]
        public int ZipCode { get; set; }
    }
}
