using AutoMapper;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Addresses;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Concretes;
using CetinFarshidfar.JewelryECommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ICustomerService _customerService;
        private readonly IMapper mapper;

        private readonly IToastNotification _toast;
        public UserController(IUserService userService, IToastNotification toast, ICustomerService customerService, IMapper mapper)
        {
            _userService = userService;
            _toast = toast;
            _customerService = customerService;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var updateProfileVM = await _userService.GetUserProfileAsync();
            return View(updateProfileVM);
        }
        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileVM updateProfileVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _userService.UserProfileUpdateAsync(updateProfileVM);
                if (result)
                {
                    _toast.AddSuccessToastMessage("Profil güncelleme işlemi tamamlandı", new ToastrOptions { Title = "İşlem Başarılı" });
                    return RedirectToAction("Profile", "User", new { Area = "Customer" });
                }
                else
                {
                    var profile = await _userService.GetUserProfileAsync();
                    _toast.AddErrorToastMessage("Profil güncelleme işlemi tamamlanamadı", new ToastrOptions { Title = "İşlem Başarısız" });
                    return View(profile);
                }
            }
            else
                return View(updateProfileVM);
        }
        [HttpGet]
        public async Task<IActionResult> Addresses()
        {
            if(TempData["CreateAddressMsg"]!=null)
                _toast.AddSuccessToastMessage("Yeni adresiniz profilinize başarıyla eklenmiştir.", new ToastrOptions { Title = "Eklendi" });
            if(TempData["UpdateAddressMsg"] != null)
                _toast.AddSuccessToastMessage("Mevcut adresinizi başarıyla güncellediniz.", new ToastrOptions { Title = "Güncellendi" });
            var addressesToList = await _customerService.GetAllAddressesByCustomerAsync();
            return View(addressesToList);
        }
        public async Task<IActionResult> AddressForm(int addressId)
        {
            if(addressId == 0)
                return ViewComponent("AddressFormPage", new AddressModel() { Id = 0 });
            var address = await _customerService.GetAddressByIdAsync(addressId);
            var map = mapper.Map<AddressModel>(address);
            return ViewComponent("AddressFormPage", map);
        }
        [HttpPost]
        public async Task<IActionResult> SaveAddress(AddressModel addressModel)
        {
            if(addressModel.Id == 0)
            {
                var addMap = mapper.Map<AddAddressVM>(addressModel);
                await _customerService.CreateAddressAsync(addMap);
                TempData["CreateAddressMsg"] = true;
                return RedirectToAction("Addresses", "User", new {Area="Customer"});
            }
            var updateMap = mapper.Map<AddressVM>(addressModel);
            await _customerService.UpdateAddressAsync(updateMap);
            TempData["UpdateAddressMsg"] = true;
            return RedirectToAction("Addresses", "User", new { Area = "Customer" });
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAddress([FromBody] ToBeDeletedModel toBeDeletedModel)
        {
            try
            {
                await _customerService.DeleteAddressAsync(toBeDeletedModel.Id);
                _toast.AddSuccessToastMessage("Adres başarıyla silindi.", new ToastrOptions { Title = "İşlem Başarılı" });
                return Ok();
            }
            catch (Exception ex)
            {
                //Hata loglanacak
                _toast.AddErrorToastMessage("Adres silinirken bir hatayla karşılaştık.", new ToastrOptions { Title = "İşlem Başarısız" });
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Settings()
        {
            return View();
        }
    }
}
