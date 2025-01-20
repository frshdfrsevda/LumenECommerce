using CetinFarshidfar.JewelryECommerce.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites
{
    public class ProductDescription : IEntityBase
    {
        [Key, ForeignKey("Product")]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public Product Product { get; set; }
    }
}
