using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.ViewComponents.Settings
{
    public class CompanySettingsArea : BaseViewComponent
    {
        private readonly ICompanyService _companyService;

        public CompanySettingsArea(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Guid? companyId = GetCompanyId();
            if (companyId == null)
                return Content("Firma bilgilerine erişilemedi lütfen giriş yapın.");
            var updateCompanyVM = await _companyService.GetCompanyByIdAsync(companyId.Value);
            return View(updateCompanyVM);
        }
    }
}
