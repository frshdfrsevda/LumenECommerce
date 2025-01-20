using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Companies;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Concretes;
using CetinFarshidfar.JewelryECommerce.Web.ResultMessages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Management.Controllers
{
    [Area("Management")]
    public class PanelAuthsController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IToastNotification toast;
        private readonly IUserService userService;

        public PanelAuthsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IToastNotification toast, IUserService userService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.toast = toast;
            this.userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserLoginVM userLoginVM)
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
                        if (userRole == "Superadmin")
                            return RedirectToAction("Index", "Dashboard", new { Area = "Management" });
                        else
                        {
                            await signInManager.SignOutAsync();
                            ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                            return View();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                        return View();
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "PanelAuths", new { Area = "Management" });
        }
    }
}
