using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions
{
    public interface ICategoryService
    {
        Task<List<CategoryWithAllPropVM>> GetAllCategoriesAsync();
        Task<List<CategoryNonIncludeVM>> GetAllCategoriesToFilterAsync();
    }
}
