using AutoMapper;
using CetinFarshidfar.JewelryECommerce.DataAccessLayer.UnitOfWorks;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Categories;
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
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;

        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
        }

        public async Task<List<CategoryWithAllPropVM>> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync(includeProperties: c => c.ChildCategories);
                var map = _mapper.Map<List<CategoryWithAllPropVM>>(categories);
                // Kategorileri gruplandır
                var groupedCategories = map
                    .Where(c => c.ParentCategoryId == null) // Root kategoriler
                    .Select(c => BuildCategoryHierarchy(c, map)) // Alt kategorileri ekle
                    .ToList();
                return groupedCategories;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        private CategoryWithAllPropVM BuildCategoryHierarchy(CategoryWithAllPropVM parent, List<CategoryWithAllPropVM> allCategories)
        {
            parent.ChildCategories = allCategories
                .Where(c => c.ParentCategoryId == parent.Id) // Parent ID'ye bağlı olanları bul
                .Select(c => BuildCategoryHierarchy(c, allCategories)) // Alt kategorileri de işleme al
                .ToList();

            return parent;
        }

        public async Task<List<CategoryNonIncludeVM>> GetAllCategoriesToFilterAsync()
        {
            var categories = await _unitOfWork.GetRepository<Category>().GetAllAsync();
            var data = categories.Select(c => new CategoryNonIncludeVM{
                        Id = c.Id,
                        Name = c.Name,
                        ParentCategoryId = c.ParentCategoryId
                    }).ToList();
            return data;
        }
    }
}
