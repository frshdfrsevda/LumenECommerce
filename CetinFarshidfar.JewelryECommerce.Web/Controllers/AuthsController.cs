using AutoMapper;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Extensions;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using CetinFarshidfar.JewelryECommerce.Web.Models;
using CetinFarshidfar.JewelryECommerce.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;

namespace CetinFarshidfar.JewelryECommerce.Web.Controllers
{
    public class AuthsController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        private readonly IUserService userService;
        private readonly IValidator<AppUser> validator;
        private readonly IToastNotification toast;
        private readonly IMapper mapper;

        public AuthsController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
            IUserService userService, IValidator<AppUser> validator, IToastNotification toast, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.userService = userService;
            this.validator = validator;
            this.toast = toast;
            this.mapper = mapper;
        }

        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                TempData["Authentication"] = true;
                return RedirectToAction("Index", "Home", new {Area=""});
            }
            var model = new AuthsModel();
            if (TempData["LoginModel"] != null)
            {
                model.UserLoginVM = JsonConvert.DeserializeObject<UserLoginVM>(TempData["LoginModel"].ToString());
            }
            if (TempData["RegisterModel"] != null)
            {
                model.UserLoginVM = JsonConvert.DeserializeObject<UserLoginVM>(TempData["RegisterModel"].ToString());
            }
            var errorsJson = HttpContext.Session.GetString("LoginErrors");

            if (!string.IsNullOrEmpty(errorsJson))
            {
                var errors = JsonConvert.DeserializeObject<List<string>>(errorsJson);
                foreach (var error in errors)
                {
                    ModelState.AddModelError("", error);
                }
                HttpContext.Session.Remove("LoginErrors");
            }

            errorsJson = HttpContext.Session.GetString("RegisterErrors");

            if (!string.IsNullOrEmpty(errorsJson))
            {
                var errors = JsonConvert.DeserializeObject<List<string>>(errorsJson);
                foreach (var error in errors)
                {
                    ModelState.AddModelError("", error);
                }
                HttpContext.Session.Remove("RegisterErrors");
            }
            if (TempData["RegisterStatus"] != null)
            {
                toast.AddSuccessToastMessage("", new ToastrOptions { Title = "Kayıt Başarılı" });
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginVM userLoginVM)
        {
            TempData["LoginModel"] = JsonConvert.SerializeObject(userLoginVM);
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(userLoginVM.Email);
                if (user != null)
                {
                    var result = await signInManager.PasswordSignInAsync(user, userLoginVM.Password, true, false);
                    if (result.Succeeded)
                    {
                        var userRole = await userService.GetUserRoleAsync(user);
                        if (userRole == "User")
                        {
                            TempData["LoginStatus"] = true;
                            return RedirectToAction("Index", "Home", new { Area = "" });
                        }
                        else
                        {
                            await signInManager.SignOutAsync();
                            ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                            HttpContext.Session.SetString("LoginErrors", JsonConvert.SerializeObject(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
                            return RedirectToAction("Index", "Auths", new { Area = ""});
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                        HttpContext.Session.SetString("LoginErrors", JsonConvert.SerializeObject(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
                        return RedirectToAction("Index", "Auths", new { Area = ""});
                    }
                }
                else
                {
                    ModelState.AddModelError("", "E-posta adresiniz veya şifreniz yanlıştır.");
                    HttpContext.Session.SetString("LoginErrors", JsonConvert.SerializeObject(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
                    return RedirectToAction("Index", "Auths", new { Area = ""});
                }
            }
            else
            {
                HttpContext.Session.SetString("LoginErrors", JsonConvert.SerializeObject(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
                return RedirectToAction("Index", "Auths", new { Area = ""});
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterVM userRegisterVM)
        {
            TempData["RegisterModel"] = JsonConvert.SerializeObject(userRegisterVM);
            var map = new AppUser() { Email=userRegisterVM.Email, FullName=userRegisterVM.FullName, PhoneNumber=userRegisterVM.PhoneNumber };
            var validation = await validator.ValidateAsync(map);
            var roles = await userService.GetAllRolesAsync();

            if (ModelState.IsValid)
            {
                var result = await userService.CreateUserAsync(userRegisterVM);
                if (result.Succeeded)
                {
                    TempData["RegisterStatus"] = true;
                    
                    return RedirectToAction("Index", "Auths", new { Area = "" });
                }
                else
                {
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    HttpContext.Session.SetString("RegisterErrors", JsonConvert.SerializeObject(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
                    return RedirectToAction("Index", "Auths", new { Area = ""});

                }
            }
            HttpContext.Session.SetString("RegisterErrors", JsonConvert.SerializeObject(ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList()));
            return RedirectToAction("Index", "Auths", new { Area = ""});
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            TempData["LogoutStatus"] = true;
            return RedirectToAction("Index", "Home", new { Area = "" });
        }
        [Authorize]
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
