using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions
{
    public interface ICustomerService
    {
        Task CreateAddressAsync(AddAddressVM addAddressVM);
        Task<AddressVM> GetAddressByIdAsync(int id);
        Task UpdateAddressAsync(AddressVM addressVM);
        Task DeleteAddressAsync(int id);
        Task<List<AddressToListVM>> GetAllAddressesByCustomerAsync();
    }
}
