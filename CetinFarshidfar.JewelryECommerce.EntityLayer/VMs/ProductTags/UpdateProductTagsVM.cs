using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductTags
{
    public class UpdateProductTagsVM
    {
        [Required(ErrorMessage ="Ürün bilgisi alınamadı.")]
        public string ProductId { get; set; }
        public List<CheckedTagVM> Tags { get; set; }
    }
}
