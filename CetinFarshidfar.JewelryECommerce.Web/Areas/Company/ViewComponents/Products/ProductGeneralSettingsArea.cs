using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.ViewComponents.Products
{
    public class ProductGeneralSettingsArea : BaseViewComponent
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductGeneralSettingsArea(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid productId)
        {
            Guid? companyId = GetCompanyId();
            if (companyId == null)
                return Content("Firma bilgilerine erişilemedi lütfen giriş yapın.");
            var (has, data) = await _productService.GetProductByIdAsync(productId, companyId.Value);
            var categories = await _categoryService.GetAllCategoriesAsync();
            ViewBag.Categories = categories;
            if(!has && (categories==null || !categories.Any()))
                return Content("Ürün bilgilerine erişilemedi, yetkiniz yok ya da ürün kaldırılmış.");
            return View(data);
        }
    }
}
