using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CetinFarshidfar.JewelryECommerce.Web.ViewComponents.Auths
{
    public class SignUpPage : ViewComponent
    {
        public IViewComponentResult Invoke(UserRegisterVM userRegisterVM)
        {
            return View(userRegisterVM);
        }
    }
}
