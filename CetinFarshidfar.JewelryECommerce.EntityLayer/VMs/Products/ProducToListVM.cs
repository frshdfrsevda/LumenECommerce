using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Products
{
    public class ProductToListVM
    {
        public Guid Id { get; set; }
        public string ProductCode { get; set; }//1
        public string Name { get; set; }//2
        public bool SpecialProduction { get; set; }//6
        public int StockQuantity { get; set; } //5
        public decimal Price { get; set; }//4
        public int? DiscountPercentage { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryVM Category { get; set; }//3
    }
}
