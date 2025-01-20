using AutoMapper;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.AutoMapper.Addresses
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CustomerAddress,AddAddressVM>().ReverseMap();
            CreateMap<CustomerAddress,AddressVM>().ReverseMap();
            CreateMap<CustomerAddress,AddressToListVM>().ReverseMap();
            CreateMap<CustomerAddress,AddressModel>().ReverseMap();
            CreateMap<AddressModel, AddAddressVM>().ReverseMap();
            CreateMap<AddressModel, AddressVM>().ReverseMap();
        }
    }
}
