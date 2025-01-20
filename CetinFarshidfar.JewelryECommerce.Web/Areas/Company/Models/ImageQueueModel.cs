using System.ComponentModel.DataAnnotations;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.Models
{
    public class ImageQueueModel
    {
        [Required(ErrorMessage ="Fotoğraf okunamadı!")]
        public int Id { get; set; }
        public int? Queue { get; set; }
    }
}
