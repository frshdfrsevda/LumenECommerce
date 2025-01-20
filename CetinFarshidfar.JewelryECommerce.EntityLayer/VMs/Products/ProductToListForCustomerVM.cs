using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Products
{
    public class ProductToListForCustomerVM
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string StockStatus { get; set; }
        public string Category { get; set; }
        public decimal ListPrice { get; set; }
        public int? DiscountPercentage { get; set; }
        public string ImagePath { get; set; }
    }
}
