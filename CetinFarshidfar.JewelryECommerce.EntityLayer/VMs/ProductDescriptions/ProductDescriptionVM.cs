using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductDescriptions
{
    public class ProductDescriptionVM
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Ürün açıklaması boş bırakılamaz.")]
        [Display(Name = "Ürün Açıklaması")]
        public string Content { get; set; }
    }
}
