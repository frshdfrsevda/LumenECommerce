using AutoMapper;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Companies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.AutoMapper.Company
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<CompanyApplication, ComApplicationAddVM>().ReverseMap();
            CreateMap<EntityLayer.Entitites.Company, UpdateCompanyVM>().ReverseMap();
            CreateMap<EntityLayer.Entitites.Company, CompanyVM>().ReverseMap();
        }
    }
}
