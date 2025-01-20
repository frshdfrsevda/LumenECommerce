using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductDescriptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Products
{
    public class UpdateGeneralSettingsVM
    {
        [Required(ErrorMessage = "Id değerine ulaşılamadı.")]
        public Guid Id { get; set; }
        [Display(Name="Ürün Kodu")]
        [Required(ErrorMessage = "Ürün kodu boş bırakılamaz.")]
        public string ProductCode { get; set; }
        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Ürün adı boş bırakılamaz.")]
        public string Name { get; set; }
        [Display(Name = "Özel Üretim ( Özel üretimse işaretleyin )")]
        [Required(ErrorMessage = "Özel üretim bilgisi seçiniz.")]
        public bool SpecialProduction { get; set; }
        [Display(Name = "Stok Miktarı")]
        public int StockQuantity { get; set; }
        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Fiyat boş bırakılamaz.")]
        public decimal Price { get; set; }
        [Display(Name = "İndirim (%) (zorunlu değil)")]
        public int? DiscountPercentage { get; set; }
        [Required(ErrorMessage = "Kargoya verilme zamanı boş bırakılamaz.")]
        [Display(Name = "Tahmini Kargolama (Gün)")]
        public int EstimatedShippingTime { get; set; }
        [Required(ErrorMessage = "Kategori bilgisi boş bırakılamaz")]
        [Display(Name = "Kategori")]
        public Guid CategoryId { get; set; }
        public ProductDescriptionVM Description { get; set; }
    }
}
