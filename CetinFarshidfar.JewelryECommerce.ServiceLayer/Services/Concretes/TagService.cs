using AutoMapper;
using CetinFarshidfar.JewelryECommerce.DataAccessLayer.UnitOfWorks;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Categories;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductTags;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Tags;
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
    public class TagService : ITagService
    {
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        public TagService(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
            _user = httpContextAccessor.HttpContext.User;
        }
        
        public async Task<List<MainTagVM>> GetProductTagsbyProductIdAsync(Guid productId)
        {
            var allTags = await unitOfWork.GetRepository<Tag>().GetAllAsync(includeProperties: t => t.ChildTags);
            var productTags = await unitOfWork.GetRepository<ProductTag>().GetAllAsync();
            var mainTagListVM = new List<MainTagVM>();
            foreach (var tag in allTags) {
                if (tag.ChildTags != null && tag.ChildTags.Any()) {
                    var mainTagVM = new MainTagVM()
                    {
                        Id = tag.Id,
                        Name = tag.Name
                    };
                    var childTagListVM = new List<ChildTagVM>();
                    foreach(var childTag in tag.ChildTags)
                    {
                        var childTagVM = new ChildTagVM()
                        {
                            Id = childTag.Id,
                            Name = childTag.Name
                        };
                        var productTag = productTags.Where(pt=>pt.TagId == childTag.Id).FirstOrDefault();
                        if (productTag != null)
                            childTagVM.hasIt = true;
                        else childTagVM.hasIt = false;
                        childTagListVM.Add(childTagVM);
                    }
                    mainTagVM.ChildTags = childTagListVM;
                    mainTagListVM.Add(mainTagVM);
                }
            }
            return mainTagListVM;
        }

        public async Task<bool> UpdateProductTagsAsync(UpdateProductTagsVM updateProductTagsVM)
        {
            try
            {
                var productId = Guid.Parse(updateProductTagsVM.ProductId);
                var product = await unitOfWork.GetRepository<Product>().GetAsync(p => p.Id == productId);
                if (product == null)
                    return false;
                foreach (var productTag in updateProductTagsVM.Tags)
                {
                    var hasProductTag = await unitOfWork.GetRepository<ProductTag>().GetAsync(pt => pt.TagId == productTag.Id && pt.ProductId == productId);
                    if (productTag.IsChecked && hasProductTag == null)
                    {
                        var productTagEntity = new ProductTag()
                        {
                            TagId = productTag.Id,
                            ProductId = productId
                        };
                        await unitOfWork.GetRepository<ProductTag>().AddAsync(productTagEntity);
                    }
                    else if (!productTag.IsChecked && hasProductTag != null)
                    {
                        await unitOfWork.GetRepository<ProductTag>().DeleteAsync(hasProductTag);
                    }
                }
                await unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<TagNonIncludeVM>> GetAllTagsToFilterAsync()
        {
            var categories = await unitOfWork.GetRepository<Tag>().GetAllAsync();
            var data = categories.Select(c => new TagNonIncludeVM
            {
                Id = c.Id,
                Name = c.Name,
                ParentTagId = c.ParentTagId
            }).ToList();
            return data;
        }
    }
}
