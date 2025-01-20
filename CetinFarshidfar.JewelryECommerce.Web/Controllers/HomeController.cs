using System.Diagnostics;
using CetinFarshidfar.JewelryECommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CetinFarshidfar.JewelryECommerce.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IToastNotification toast;
        public HomeController(ILogger<HomeController> logger, IToastNotification toast)
        {
            _logger = logger;
            this.toast = toast;
        }

        public IActionResult Index()
        {
            if (TempData["LoginStatus"] != null)
            {
                toast.AddSuccessToastMessage("", new ToastrOptions { Title = "Giriþ Baþarýlý" });
            }
            if (TempData["LogoutStatus"] != null)
            {
                toast.AddSuccessToastMessage("", new ToastrOptions { Title = "Çýkýþ Baþarýlý" });
            }
            if (TempData["Authentication"] != null)
            {
                toast.AddSuccessToastMessage("", new ToastrOptions { Title = "Zaten giriþ yaptýnýz" });
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
