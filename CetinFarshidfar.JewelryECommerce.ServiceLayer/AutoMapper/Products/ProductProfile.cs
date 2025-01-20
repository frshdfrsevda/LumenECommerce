using AutoMapper;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.AutoMapper.Company
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductToListVM>().ReverseMap();
            CreateMap<Product, UpdateGeneralSettingsVM>().ReverseMap();
            CreateMap<Product, ProductWithCategoryAndImagesVM>().ReverseMap();
        }
    }
}
