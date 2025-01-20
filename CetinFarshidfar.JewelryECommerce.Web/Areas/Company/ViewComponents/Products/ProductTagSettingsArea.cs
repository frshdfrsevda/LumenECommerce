using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.ViewComponents.Products
{
    public class ProductTagSettingsArea : BaseViewComponent
    {
        private readonly ITagService _tagService;

        public ProductTagSettingsArea(ITagService tagService)
        {
            _tagService = tagService;
        }

        public async Task<IViewComponentResult> InvokeAsync(Guid productId)
        {
            Guid? companyId = GetCompanyId();
            if (companyId == null)
                return Content("Firma bilgilerine erişilemedi lütfen giriş yapın.");
            var productTagsVM = await _tagService.GetProductTagsbyProductIdAsync(productId);
            ViewBag.ProductId = productId.ToString();
            return View(productTagsVM);
        }
    }
}
