using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Categories
{
    public class CategoryWithAllPropVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public virtual ICollection<CategoryWithAllPropVM> ChildCategories { get; set; } = new List<CategoryWithAllPropVM>();
    }
}
