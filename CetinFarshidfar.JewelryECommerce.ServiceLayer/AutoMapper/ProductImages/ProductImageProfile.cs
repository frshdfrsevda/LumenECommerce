using AutoMapper;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductImages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.AutoMapper.ProductImages
{
    public class ProductImageProfile : Profile
    {
        public ProductImageProfile() { 
            CreateMap<ProductImage,ProductImageVM>().ReverseMap();
            CreateMap<ProductImage, AddProductImageVM>().ReverseMap();
        }
    }
}
