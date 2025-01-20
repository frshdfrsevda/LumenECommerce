using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductImages;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions
{
    public interface IProductService
    {
        Task<(int recordsTotal,List<ProductToListVM>)> GetAllProductsByCompanyIdAsync(Guid companyId, string? searchValue, int skip, int pageSize, string? sortColumn, string? sortColumnDirection);
        Task<(bool, UpdateGeneralSettingsVM?)> GetProductByIdAsync(Guid productId, Guid companyId);
        Task<bool> UpdateProductGeneralSettingsAsync(UpdateGeneralSettingsVM updateGeneralSettingsVM);
        Task<(bool, List<ProductImageVM>?)> GetProductImagesByProductIdAsync(Guid productId);
        Task<bool> UpdateProductImageQueueAsync(int photoImageId, int? queue);
        Task<bool> DeleteProductImageAsync(int photoImageId);
        Task<bool> CreateProductImageAsync(AddProductImageVM addProductImageVM);
        Task<(bool, List<ProductToListForCustomerVM>?)> GetAllProductsToListAsync();
        Task<(bool, ProductWithCategoryAndImagesVM?)> GetProductWithImagesCategoryCompanyAsync(Guid productId);
    }
}
