using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Tags
{
    public class TagNonIncludeVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentTagId { get; set; }
    }
}
