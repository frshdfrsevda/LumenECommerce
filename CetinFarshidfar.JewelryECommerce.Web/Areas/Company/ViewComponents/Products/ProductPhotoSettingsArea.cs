using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.ViewComponents.Products
{
    public class ProductPhotoSettingsArea : BaseViewComponent
    {
        private readonly IProductService _productService;

        public ProductPhotoSettingsArea(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid productId)
        {
            Guid? companyId = GetCompanyId();
            if (companyId == null)
                return Content("Firma bilgilerine erişilemedi lütfen giriş yapın.");
            var (has, data) = await _productService.GetProductImagesByProductIdAsync(productId);
            if(!has)
                return Content("İşlem yapılırken bir hata oluştu. Ürün çoktan silinmiş olabilir.");
            ViewBag.ProductId = productId.ToString();
            return View(data);
        }
    }
}
