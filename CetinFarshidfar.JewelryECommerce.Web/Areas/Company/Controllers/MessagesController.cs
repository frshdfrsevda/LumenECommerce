using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.Controllers
{
    [Area("Company")]
    [Authorize(Roles = "CompanyMod")]
    public class MessagesController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
