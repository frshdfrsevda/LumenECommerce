using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CetinFarshidfar.JewelryECommerce.Web.ViewComponents.Auths
{
    public class SignInPage : ViewComponent
    {
        public IViewComponentResult Invoke(UserLoginVM userLoginVM)
        {
            return View(userLoginVM);
        }
    }
}
