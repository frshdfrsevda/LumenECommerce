using AutoMapper;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductDescriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.AutoMapper.ProductDescriptions
{
    public class ProductDescriptionProfile : Profile
    {
        public ProductDescriptionProfile()
        {
            CreateMap<ProductDescription, ProductDescriptionVM>().ReverseMap();
        }
    }
}
