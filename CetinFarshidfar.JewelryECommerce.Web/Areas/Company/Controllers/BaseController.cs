using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.Controllers
{
    [Authorize(Roles = "CompanyMod")]
    [Area("Company")]
    public class BaseController : Controller
    {
        protected Guid CompanyId { get; private set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            string companyIdString = HttpContext.Session.GetString("CompanyId");
            if (!string.IsNullOrEmpty(companyIdString) && Guid.TryParse(companyIdString, out Guid companyId))
            {
                CompanyId = companyId;
            }
            else
            {
                // CompanyId sessionda bulunamazsa veya geçersizse yapılacak işlemler
                // Örneğin, kullanıcıyı oturum açma sayfasına yönlendirebilirsiniz.
                context.Result = RedirectToAction("Index", "Authentications", new { Area = "Company" });
            }
        }
    }
}
