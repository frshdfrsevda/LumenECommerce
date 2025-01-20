
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductTags;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions
{
    public interface ITagService
    {
        Task<List<MainTagVM>> GetProductTagsbyProductIdAsync(Guid productId);
        Task<bool> UpdateProductTagsAsync(UpdateProductTagsVM updateProductTagsVM);
        Task<List<TagNonIncludeVM>> GetAllTagsToFilterAsync();
    }
}
