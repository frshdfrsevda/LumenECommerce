using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.ViewComponents
{
    public abstract class BaseViewComponent : ViewComponent
    {
        protected Guid? GetCompanyId()
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("CompanyMod"))
            {
                string companyIdString = HttpContext.Session.GetString("CompanyId");
                if (!string.IsNullOrEmpty(companyIdString) && Guid.TryParse(companyIdString, out Guid companyId))
                {
                    return companyId;
                }
                return null;
            }
            return null; // Geçersiz veya bulunamayan CompanyId için null döner
        }
    }
}
