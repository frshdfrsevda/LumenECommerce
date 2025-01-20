using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Addresses;
using Microsoft.AspNetCore.Mvc;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Customer.ViewComponents.User
{
    public class AddressFormPage : ViewComponent
    {
        public IViewComponentResult Invoke(AddressModel addressModel)
        {
            return View(addressModel);
        }
    }
}
