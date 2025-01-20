using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductTags
{
    public class CheckedTagVM
    {
        [Required(ErrorMessage = "Tag bilgisi alınamadı.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Tag bilgisi okunamadı.")]
        public bool IsChecked { get; set; }
    }
}
