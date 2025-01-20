using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.ViewComponents.Settings
{
    public class ProfileSettingsArea : BaseViewComponent
    {
        private readonly IUserService _userService;

        public ProfileSettingsArea(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Guid? companyId = GetCompanyId();
            if (companyId == null)
                return Content("Firma bilgilerine erişilemedi lütfen giriş yapın.");
            var userVM = await _userService.GetUserWithRoleAsync();
            return View(userVM);
        }
    }
}
