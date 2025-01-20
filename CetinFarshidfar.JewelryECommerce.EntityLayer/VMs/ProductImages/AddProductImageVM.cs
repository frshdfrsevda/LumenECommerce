using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductImages
{
    public class AddProductImageVM
    {
        [Required(ErrorMessage = "Bir fotoğraf seçmediniz.")]
        public string Path { get; set; }
        public int? Queue { get; set; }
        [Required(ErrorMessage = "Fotoğraf eklenilmek istenen ürüne erişilemedi.")]
        public Guid ProductId { get; set; }
    }
}
