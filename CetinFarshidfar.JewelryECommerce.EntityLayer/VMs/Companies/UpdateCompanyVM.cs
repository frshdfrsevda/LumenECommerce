using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Companies
{
    public class UpdateCompanyVM
    {
        [Display(Name = "Firma ID")]
        [Required(ErrorMessage = "Firma ID değeri alınamadı.")]
        public Guid Id { get; set; }
        [Display(Name="Firma İsmi")]
        [Required(ErrorMessage = "Firma İsmi boş bırakılamaz.")]
        public string Name { get; set; }
        [Display(Name = "Firma Adresi")]
        [Required(ErrorMessage = "Firma Adresi boş bırakılamaz.")]
        public string Address { get; set; }
        [Display(Name = "Şehir")]
        [Required(ErrorMessage = "Şehir boş bırakılamaz.")]
        public string City { get; set; }
        [Display(Name = "Bölge / Eyalet")]
        [Required(ErrorMessage = "Bölge / Eyalet boş bırakılamaz.")]
        public string State { get; set; }
        [Display(Name = "Posta Kodu")]
        [Required(ErrorMessage = "Posta Kodu boş bırakılamaz.")]
        public string PostalCode { get; set; }
        [Display(Name = "Ülke")]
        [Required(ErrorMessage = "Ülke boş bırakılamaz.")]
        public string Country { get; set; }
        [Display(Name = "Firma Telefon Numarası")]
        [Required(ErrorMessage = "Firma Telefon Numarası boş bırakılamaz.")]
        public string Phone { get; set; }
        [Display(Name = "Firma Email Adresi")]
        [Required(ErrorMessage = "Firma Email Adresi boş bırakılamaz.")]
        public string Email { get; set; }
        [Display(Name = "Firma Websitesi (Zorunlu değil)")]
        public string? Website { get; set; }
        [Display(Name = "Firma Kuruluş Tarihi")]
        [Required(ErrorMessage = "Firma Kuruluş Tarihi boş bırakılamaz.")]
        public DateTime FoundedDate { get; set; }
        [Display(Name = "Firma Çalışan Sayısı")]
        [Required(ErrorMessage = "Firma Çalışan Sayısı boş bırakılamaz.")]
        public int NumberOfEmployees { get; set; }
        [Display(Name = "Hizmet Alanı")]
        [Required(ErrorMessage = "Hizmet Alanı boş bırakılamaz.")]
        public string Industry { get; set; }
        [Display(Name = "Firma Hakkında")]
        [Required(ErrorMessage = "Firma Hakkında boş bırakılamaz.")]
        public string Description { get; set; }
        [Display(Name = "Son Güncelleyen")]
        public string? ModifiedBy { get; set; }
        [Display(Name = "Son Güncelleme Zamanı")]
        public DateTime? ModifiedDate { get; set; }
    }
}
