using AutoMapper;
using CetinFarshidfar.JewelryECommerce.DataAccessLayer.UnitOfWorks;
using CetinFarshidfar.JewelryECommerce.EntityLayer.Entitites;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Products;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Extensions;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductImages;
using System.Collections;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Helpers.Images;
namespace CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly ClaimsPrincipal _user;
        private readonly IImageHelper _imageHelper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, IImageHelper imageHelper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            this.httpContextAccessor = httpContextAccessor;
            _user = httpContextAccessor.HttpContext.User;
            _imageHelper = imageHelper;
        }

        public async Task<(int recordsTotal, List<ProductToListVM>)> GetAllProductsByCompanyIdAsync(Guid companyId, string? searchValue, int skip, int pageSize, string? sortColumn, string? sortColumnDirection)
        {
            var productData = _unitOfWork.GetRepository<Product>().GetAllAsQuerable(p=> p.CompanyId == companyId && !p.IsDeleted, pr=>pr.Category);

            // Arama kriterlerine göre filtreleme yapar
            if (!string.IsNullOrEmpty(searchValue))
            {
                productData = productData.Where(m => m.Name.Contains(searchValue)
                                                  || m.ProductCode.Contains(searchValue));
            }
            int recordsTotal = 0;
            // Toplam kayıt sayısını alır
            recordsTotal = productData.Count();

            
            // Sütun adlarını belirleyin
            var columnNames = new[] { "ProductCode", "Name", "Category.Name", "Price", "DiscountPercentage", "StockQuantity", "SpecialProduction" };
            var sortCol = columnNames[Convert.ToInt32(sortColumn)];

            // Sıralama işlemi
            // Sıralama işlemi
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            {
                var sortExpression = $"{sortCol} {sortColumnDirection}";
                productData = productData.OrderBy(sortExpression);
            }
            // İlgili sayfadaki verileri çeker
            var data = productData.Skip(skip).Take(pageSize).ToList();
            var map = _mapper.Map<List<ProductToListVM>>(data);
            return (recordsTotal, map);
        }
        
        public async Task<(bool, UpdateGeneralSettingsVM?)> GetProductByIdAsync(Guid productId, Guid companyId)
        {
            try
            {
                var product = await _unitOfWork.GetRepository<Product>().GetAsync(p => p.CompanyId == companyId && p.Id == productId, pr => pr.Description);
                if (product == null)
                    return (false, null);
                var map = _mapper.Map<UpdateGeneralSettingsVM>(product);
                return (true, map);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }
        public async Task<bool> UpdateProductGeneralSettingsAsync(UpdateGeneralSettingsVM updateGeneralSettingsVM)
        {
            try
            {
                var product = await _unitOfWork.GetRepository<Product>().GetAsync(p=> p.Id == updateGeneralSettingsVM.Id, pr => pr.Description);
                if (product == null)
                    return false;
                _mapper.Map(updateGeneralSettingsVM,product);
                product.ModifiedBy = _user.GetLoggedInEmail();
                product.ModifiedDate = DateTime.Now;
                await _unitOfWork.GetRepository<Product>().UpdateAsync(product);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<(bool, List<ProductImageVM>?)> GetProductImagesByProductIdAsync(Guid productId)
        {
            try
            {
                var productImages = await _unitOfWork.GetRepository<ProductImage>().GetAllAsync(pi=>pi.ProductId==productId);
                if (productImages == null || !productImages.Any())
                    return (false, null);
                var map = _mapper.Map<List<ProductImageVM>>(productImages);
                return (true, map.OrderBy(pi=>pi.Queue).ToList());
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }
        public async Task<bool> UpdateProductImageQueueAsync(int photoImageId, int? queue)
        {
            try
            {
                var productImage = await _unitOfWork.GetRepository<ProductImage>().GetAsync(pi => pi.Id == photoImageId);
                if (productImage == null)
                    return false;
                productImage.Queue = queue;
                await _unitOfWork.GetRepository<ProductImage>().UpdateAsync(productImage);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteProductImageAsync(int photoImageId)
        {
            try
            {
                var productImage = await _unitOfWork.GetRepository<ProductImage>().GetAsync(pi => pi.Id == photoImageId);
                if (productImage == null)
                    return false;
                await _unitOfWork.GetRepository<ProductImage>().DeleteAsync(productImage);
                await _unitOfWork.SaveAsync();
                _imageHelper.Delete(productImage.Path);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> CreateProductImageAsync(AddProductImageVM addProductImageVM)
        {
            try
            {
                var product = await _unitOfWork.GetRepository<Product>().GetAsync(p => p.Id == addProductImageVM.ProductId);
                if (product == null)
                    return false;
                var map = _mapper.Map<ProductImage>(addProductImageVM);
                await _unitOfWork.GetRepository<ProductImage>().AddAsync(map);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<(bool, List<ProductToListForCustomerVM>?)> GetAllProductsToListAsync()
        {
            try
            {
                var products = await _unitOfWork.GetRepository<Product>().GetAllAsync(p => p.IsDeleted == false, x=>x.Category, y=>y.Company);
                var productToListForCustomerVMList = new List<ProductToListForCustomerVM>();
                foreach (var product in products)
                {
                    var listPrice = product.DiscountPercentage == null ? product.Price : product.Price-(product.Price*product.DiscountPercentage/100);
                    var stockStatus = product.SpecialProduction ? "Özel Üretim" : $"{product.StockQuantity}";
                    var title = $"<b>{product.Company.Name}</b> {product.ProductCode} {product.Name}";
                    var images = await _unitOfWork.GetRepository<ProductImage>().GetAllAsync(pi => pi.ProductId == product.Id);
                    var firstImage = images.OrderBy(i=>i.Queue).FirstOrDefault();
                    var productToListForCustomerVM = new ProductToListForCustomerVM()
                    {
                        Id = product.Id,
                        Category = product.Category.Name,
                        DiscountPercentage = product.DiscountPercentage,
                        ListPrice = listPrice.Value,
                        Title = title,
                        StockStatus = stockStatus,
                        ImagePath = firstImage.Path
                    };
                    productToListForCustomerVMList.Add(productToListForCustomerVM);
                }
                return (true, productToListForCustomerVMList);
            }
            catch (Exception ex)
            {
                return (false, null);
            }
        }
        public async Task<(bool, ProductWithCategoryAndImagesVM?)> GetProductWithImagesCategoryCompanyAsync(Guid productId)
        {
            try
            {
                var product = await _unitOfWork.GetRepository<Product>().GetAsync(p=>p.Id== productId && p.IsDeleted == false, x=>x.Category,y=>y.Company,z=>z.Images);
                if(product == null)
                    return (false, null);
                var map = _mapper.Map<ProductWithCategoryAndImagesVM>(product);
                return (true, map);
            }
            catch (Exception ex)
            {
                return (false,null);
            }

        }
    }
}
