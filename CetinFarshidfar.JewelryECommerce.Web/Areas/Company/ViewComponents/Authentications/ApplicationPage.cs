
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Companies;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.ViewComponents.Authentications
{
    public class ApplicationPage : ViewComponent
    {
        public IViewComponentResult Invoke(ComApplicationAddVM comApplicationAddVM)
        {
            return View(comApplicationAddVM);
        }
    }
}
