using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;

namespace CetinFarshidfar.JewelryECommerce.Web.Models
{
    public class AuthsModel
    {
        public UserRegisterVM UserRegisterVM { get; set; } = new UserRegisterVM();
        public UserLoginVM UserLoginVM { get; set; } = new UserLoginVM();
    }
}
