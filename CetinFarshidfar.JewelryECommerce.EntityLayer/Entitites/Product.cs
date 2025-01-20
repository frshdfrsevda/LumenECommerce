using CetinFarshidfar.JewelryECommerce.CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites
{
    public class Product : EntityBase
    {

        public string ProductCode { get; set; }
        public string Name { get; set; }
        public bool SpecialProduction { get; set; }
        public int StockQuantity { get; set; } = 0;
        public decimal Price { get; set; }
        public int? DiscountPercentage { get; set; }
        public int EstimatedShippingTime { get; set; }
        public Guid CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        public Guid CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
        public ProductDescription Description { get; set; }
        public ICollection<ProductImage> Images { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
