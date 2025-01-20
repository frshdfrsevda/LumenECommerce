using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Companies;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.Models
{
    public class ComAuthsModel
    {
        public UserLoginVM UserLoginVM { get; set; } = new UserLoginVM();
        public ComApplicationAddVM ComApplicationAddVM { get; set; } = new ComApplicationAddVM();
    }
}
