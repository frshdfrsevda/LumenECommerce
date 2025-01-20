using AutoMapper;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Companies;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using CetinFarshidfar.JewelryECommerce.Web.Areas.Company.Models;
using CetinFarshidfar.JewelryECommerce.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.Controllers
{
    [Area("Company")]
    public class AuthenticationsController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IUserService userService;
        private readonly IToastNotification toast;
        private readonly ICompanyService companyService;

        public AuthenticationsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IUserService userService, IToastNotification toast, ICompanyService companyService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.toast = toast;
            this.companyService = companyService;
        }

        public IActionResult Index()
        {
            var comAuthsModel= new ComAuthsModel();
            if(TempData["ApplicationMsg"]!=null)
                toast.AddSuccessToastMessage(Messages.Company.Application(TempData["ApplicationMsg"]!.ToString()!), new ToastrOptions { Title = "İşlem Başarılı" });
            if (TempData["ComLoginModel"] != null)
            {
                comAuthsModel.UserLoginVM = JsonConvert.DeserializeObject<UserLoginVM>(TempData["ComLoginModel"]!.ToString()!)!;
            }
            if (TempData["ApplicationModel"] != null)
            {
                comAuthsModel.ComApplicationAddVM = JsonConvert.DeserializeObject<ComApplicationAddVM>(TempData["ApplicationModel"]!.ToString()!)!;
            }
            string errorMsg = "";
            var errorsJson = HttpContext.Session.GetString("ApplicationErrors");

            if (!string.IsNullOrEmpty(errorsJson))
            {
                errorMsg += string.Join(" ", JsonConvert.DeserializeObject<List<string>>(errorsJson)!);
                HttpContext.Session.Remove("ApplicationErrors");
            }

            errorsJson = HttpContext.Session.GetString("ComLoginErrors");

            if (!string.IsNullOrEmpty(errorsJson))
            {
                errorMsg += string.Join(" ", JsonConvert.DeserializeObject<List<string>>(errorsJson)!);
                HttpContext.Session.Remove("ComLoginErrors");
            }
            if(errorMsg!="")
                toast.AddErrorToastMessage(errorMsg, new ToastrOptions { Title = "BAŞARISIZ!", TimeOut=30000 });
            return View(comAuthsModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginVM.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginVM.Password, true, false);
                    if (result.Succeeded)
                    {
                        var userRole = await userService.GetUserRoleAsync(user);
                        if(userRole == "CompanyMod")
                        {
                            // İşlem başarılı
                            var companyId = await companyService.GetCompanyIdByCoFounderAsync(user.Id);
                            // Şirket bilgisi alınır - Id değeri Guid to string
                            HttpContext.Session.SetString("CompanyId", companyId.ToString());
                            return RedirectToAction("Index", "Dashboard", new { Area = "Company"});
                        }
                        else
                        {
                            await signInManager.SignOutAsync();
                        }
                    }
                }
                ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
            }
            var errors = ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();
            HttpContext.Session.SetString("ComLoginErrors", JsonConvert.SerializeObject(errors));
            TempData["ComLoginModel"] = JsonConvert.SerializeObject(userLoginVM);
            return RedirectToAction("Index", "Authentications", new { Area = "Company" });
        }
        [HttpPost]
        public async Task<IActionResult> Application(ComApplicationAddVM comApplicationAddVM)
        {
            if (ModelState.IsValid)
            {
                await companyService.CreateComApplicationAsync(comApplicationAddVM);
                TempData["ApplicationMsg"] = comApplicationAddVM.ComName;
                return RedirectToAction("Index", "Authentications", new { Area = "Company" });
            }
            var errors = ModelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();
            HttpContext.Session.SetString("ApplicationErrors", JsonConvert.SerializeObject(errors));
            TempData["ApplicationModel"] = JsonConvert.SerializeObject(comApplicationAddVM);
            return RedirectToAction("Index", "Authentications", new { Area = "Company" });
        }
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Remove("CompanyId");
            return RedirectToAction("Index", "Authentications", new { Area = "Company" });
        }
    }
}
