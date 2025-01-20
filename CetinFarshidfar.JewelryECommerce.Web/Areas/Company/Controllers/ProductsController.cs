using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductImages;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Products;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.ProductTags;
using CetinFarshidfar.JewelryECommerce.EntityLayer.VMs.Users;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Helpers.Images;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Concretes;
using CetinFarshidfar.JewelryECommerce.Web.Areas.Company.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CetinFarshidfar.JewelryECommerce.Web.Areas.Company.Controllers
{
    [Area("Company")]
    [Authorize(Roles = "CompanyMod")]
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IImageHelper _imageHelper;
        private readonly ITagService _tagService;
        public ProductsController(IProductService productService, ICategoryService categoryService, IImageHelper imageHelper, ITagService tagService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _imageHelper = imageHelper;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Product(string productId)
        {
            var guidProductId = Guid.Parse(productId);
            var model = new IdAndNameModel() { Id = guidProductId, Name="Ürün Adı Gelecek" };
            return View(model);
        }
        [HttpGet]
        public IActionResult ProductGeneralSettings(string productId)
        {
            var guidProductId = Guid.Parse(productId);
            return ViewComponent("ProductGeneralSettingsArea", guidProductId);
        }
        [HttpPost]
        public async Task<JsonResult> ProductGeneralSettings(UpdateGeneralSettingsVM updateGeneralSettingsVM)
        {
            if(updateGeneralSettingsVM.SpecialProduction)
            {
                ModelState.Remove("StockQuantity");
                updateGeneralSettingsVM.StockQuantity = 0;
            }
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join("|", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Json(new { success = false, message = errorMessages });
            }
            var isCompleted = await _productService.UpdateProductGeneralSettingsAsync(updateGeneralSettingsVM);
            if (isCompleted)
                return Json(new { success = true, message = "Güncelleme işlemi başarılı." });
            return Json(new { success = false, message = "İstek işlenirken bir hata oluştu, lütfen daha sonra tekrar deneyiniz." });
        }
        [HttpGet]
        public IActionResult ProductPhotoSettings(string productId)
        {
            var guidProductId = Guid.Parse(productId);
            return ViewComponent("ProductPhotoSettingsArea", guidProductId);
        }
        [HttpPost]
        public async Task<JsonResult> UpdateImageQueue([FromBody] ImageQueueModel imageQueueModel)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join("|", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Json(new { success = false, message = errorMessages });
            }
            var isCompleted = await _productService.UpdateProductImageQueueAsync(imageQueueModel.Id, imageQueueModel.Queue);
            if (isCompleted)
                return Json(new { success = true, message = "Güncelleme işlemi başarılı." });
            return Json(new { success = false, message = "İstek işlenirken bir hata oluştu, lütfen daha sonra tekrar deneyiniz." });
        }
        [HttpPost]
        public async Task<JsonResult> DeleteProductImage([FromBody] ImageQueueModel imageQueueModel)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join("|", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Json(new { success = false, message = errorMessages });
            }
            var isCompleted = await _productService.DeleteProductImageAsync(imageQueueModel.Id);
            if (isCompleted)
                return Json(new { success = true, message = "Silme işlemi başarılı." });
            return Json(new { success = false, message = "İstek işlenirken bir hata oluştu, lütfen daha sonra tekrar deneyiniz." });
        }
        [HttpPost]
        public async Task<JsonResult> AddProductImage(AddProductImageModel addProductImageModel)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join("|", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Json(new { success = false, message = errorMessages });
            }
            var path = await _imageHelper.Upload(addProductImageModel.File, addProductImageModel.ProductId.ToString());
            var addProductImageVM = new AddProductImageVM()
            {
                Path = path,
                Queue = addProductImageModel.Queue,
                ProductId = Guid.Parse(addProductImageModel.ProductId)
            };
            var isCompleted = await _productService.CreateProductImageAsync(addProductImageVM);
            if (isCompleted)
                return Json(new { success = true, message = "Ekleme işlemi başarılı." });
            return Json(new { success = false, message = "İstek işlenirken bir hata oluştu, lütfen daha sonra tekrar deneyiniz." });
        }
        [HttpGet]
        public IActionResult ProductTagSettings(string productId)
        {
            var guidProductId = Guid.Parse(productId);
            return ViewComponent("ProductTagSettingsArea", guidProductId);
        }
        [HttpPost]
        public async Task<JsonResult> ProductTagSettings([FromBody] UpdateProductTagsVM updateProductTagsVM)
        {
            if (!ModelState.IsValid)
            {
                string errorMessages = string.Join("|", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
                return Json(new { success = false, message = errorMessages });
            }
            var isCompleted = await _tagService.UpdateProductTagsAsync(updateProductTagsVM);
            if (isCompleted)
                return Json(new { success = true, message = "Güncelleme işlemi başarılı." });
            return Json(new { success = false, message = "İstek işlenirken bir hata oluştu, lütfen daha sonra tekrar deneyiniz." });
        }
        [HttpGet]
        public IActionResult AddNewProduct()
        {
            return View();
        }
        [HttpGet]
        public async Task<JsonResult> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var categoriesJson = JsonConvert.SerializeObject(categories);
            return Json(categoriesJson);
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            // DataTables için gerekli olan parametreleri alır
            var draw = HttpContext.Request.Query["draw"].FirstOrDefault();
            var start = HttpContext.Request.Query["start"].FirstOrDefault();
            var length = HttpContext.Request.Query["length"].FirstOrDefault();
            var sortColumn = HttpContext.Request.Query["order[0][column]"].FirstOrDefault();
            var sortColumnDirection = HttpContext.Request.Query["order[0][dir]"].FirstOrDefault();
            var searchValue = HttpContext.Request.Query["search[value]"].FirstOrDefault();

            // Sayfa boyutunu ve kaç adet veri atlanacağını belirler
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            // Ürün verilerini veritabanından alır ve sorgulanabilir hale getirir
            var (recordsTotal, data) = await _productService.GetAllProductsByCompanyIdAsync(CompanyId,searchValue,skip,pageSize, sortColumn, sortColumnDirection);

            // DataTables için gerekli olan JSON yapısını oluşturur
            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(jsonData);
        }
    }
}
