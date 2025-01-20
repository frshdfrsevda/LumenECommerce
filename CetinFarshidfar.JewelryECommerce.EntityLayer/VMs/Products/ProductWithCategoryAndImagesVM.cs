using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Categories;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Companies;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductImages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Products
{
    public class ProductWithCategoryAndImagesVM
    {
        public Guid Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public bool SpecialProduction { get; set; }
        public int StockQuantity { get; set; } = 0;
        public decimal Price { get; set; }
        public int? DiscountPercentage { get; set; }
        public int EstimatedShippingTime { get; set; }
        public CategoryVM Category { get; set; }
        public CompanyVM Company { get; set; }
        public List<ProductImageVM> Images { get; set; }
    }
}
