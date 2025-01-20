using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Companies;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.ViewComponents.Authentications
{
    public class ComLoginPage : ViewComponent
    {
        public IViewComponentResult Invoke(UserLoginVM userLoginVM)
        {
            return View(userLoginVM);
        }
    }
}
