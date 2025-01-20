using System.ComponentModel.DataAnnotations;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.Models
{
    public class AddProductImageModel
    {
        [Required(ErrorMessage = "Bir fotoğraf seçmediniz.")]
        public IFormFile File { get; set; }
        public int? Queue { get; set; }
        [Required(ErrorMessage = "Fotoğraf eklenilmek istenen ürüne erişilemedi.")]
        public string ProductId { get; set; }
    }
}
