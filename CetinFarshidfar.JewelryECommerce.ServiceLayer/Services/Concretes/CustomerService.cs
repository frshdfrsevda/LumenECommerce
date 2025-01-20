using AutoMapper;
using CetinFarshidfar.JewelryECommerce.DataAccessLayer.UnitOfWorks;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Addresses;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Extensions;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Concretes
{
    public class CustomerService : ICustomerService
    {

        private readonly ClaimsPrincipal _user;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task CreateAddressAsync(AddAddressVM addAddressVM)
        {
            try
            {
                var map = mapper.Map<CustomerAddress>(addAddressVM);
                map.UserId = _user.GetLoggedInUserId();
                await unitOfWork.GetRepository<CustomerAddress>().AddAsync(map);
                await unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama veya başka işlemler yapılabilir
                throw new InvalidOperationException("Bir hata oluştu", ex);
            }
        }

        public async Task DeleteAddressAsync(int id)
        {
            try
            {
                var customerAddress=await unitOfWork.GetRepository<CustomerAddress>().GetAsync(ca=>ca.Id==id);
                await unitOfWork.GetRepository<CustomerAddress>().DeleteAsync(customerAddress);
                await unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama veya başka işlemler yapılabilir
                throw new InvalidOperationException("Bir hata oluştu", ex);
            }
        }

        public async Task<AddressVM> GetAddressByIdAsync(int id)
        {
            try
            {
                var customerAddress = await unitOfWork.GetRepository<CustomerAddress>().GetAsync(ca => ca.Id == id);
                return mapper.Map<AddressVM>(customerAddress);
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama veya başka işlemler yapılabilir
                throw new InvalidOperationException("Bir hata oluştu", ex);
            }
        }

        public async Task<List<AddressToListVM>> GetAllAddressesByCustomerAsync()
        {
            try
            {
                var userId = _user.GetLoggedInUserId();
                var customerAddresses = await unitOfWork.GetRepository<CustomerAddress>().GetAllAsync(ca => ca.UserId == userId);
                return mapper.Map<List<AddressToListVM>>(customerAddresses);
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama veya başka işlemler yapılabilir
                throw new InvalidOperationException("Bir hata oluştu", ex);
            }
        }

        public async Task UpdateAddressAsync(AddressVM addressVM)
        {
            try
            {
                var customerAddress = await unitOfWork.GetRepository<CustomerAddress>().GetAsync(ca => ca.Id == addressVM.Id);
                mapper.Map(addressVM, customerAddress);
                await unitOfWork.GetRepository<CustomerAddress>().UpdateAsync(customerAddress);
                await unitOfWork.SaveAsync();
            }
            catch (Exception ex)
            {
                // Hata durumunda loglama veya başka işlemler yapılabilir
                throw new InvalidOperationException("Bir hata oluştu", ex);
            }
        }
    }
}
