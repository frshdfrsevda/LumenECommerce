using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Companies;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.Controllers
{
    public class SettingsController : BaseController
    {
        private readonly ICompanyService _companyService;
        private readonly IUserService _userService;

        public SettingsController(ICompanyService companyService, IUserService userService)
        {
            _companyService = companyService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CompanySettings()
        {
            return ViewComponent("CompanySettingsArea");
        }
        public IActionResult ProfileSettings()
        {
            return ViewComponent("ProfileSettingsArea");
        }
        public IActionResult PasswordSettings()
        {
            return ViewComponent("PasswordSettingsArea");
        }
        [HttpPost]
        public async Task<JsonResult> UpdateCompany(UpdateCompanyVM updateCompanyVM)
        {
            if (!ModelState.IsValid) {
                string errorMessages = string.Join("|", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Json(new { success = false, message = errorMessages });
            }
            var isCompleted = await _companyService.UpdateCompanyAsync(updateCompanyVM);
            if(isCompleted)
                return Json(new {success = true, message="Güncelleme işlemi başarılı."});
            return Json(new {success = false, message="İstek işlenirken bir hata oluştu, lütfen daha sonra tekrar deneyiniz."});
        }
        [HttpPost]
        public async Task<JsonResult> UpdateProfileSettings(UserVM userVM)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join("|", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Json(new { success = false, message = errorMessages });
            }
            var isCompleted = await _userService.ProfileSettingsUpdateAsync(userVM);
            if (isCompleted)
                return Json(new { success = true, message = "Güncelleme işlemi başarılı." });
            return Json(new { success = false, message = "İstek işlenirken bir hata oluştu, lütfen daha sonra tekrar deneyiniz." });
        }
        [HttpPost]
        public async Task<JsonResult> UpdatePassword(UserNewPasswordVM userNewPasswordVM)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join("|", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Json(new { success = false, message = errorMessages });
            }
            var isCompleted = await _userService.ChangePasswordAsync(userNewPasswordVM);
            if (isCompleted)
                return Json(new { success = true, message = "Güncelleme işlemi başarılı." });
            return Json(new { success = false, message = "İstek işlenirken bir hata oluştu, lütfen daha sonra tekrar deneyiniz." });
        }
    }
}
