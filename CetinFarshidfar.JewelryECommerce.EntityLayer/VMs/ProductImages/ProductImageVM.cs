using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductImages
{
    public class ProductImageVM
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public int? Queue { get; set; }
        public Guid ProductId { get; set; }
    }
}
