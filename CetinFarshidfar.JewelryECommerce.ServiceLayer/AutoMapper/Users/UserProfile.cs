using AutoMapper;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.AutoMapper.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<AppUser, UserVM>().ReverseMap();
            CreateMap<AppUser, UserAddVM>().ReverseMap();
            CreateMap<AppUser, UserUpdateVM>().ReverseMap();
            CreateMap<AppUser, UserProfileVM>().ReverseMap();
        }
    }
}
