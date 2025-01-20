using CetinFarshidfar.JewelryECommerce.ServiceLayer.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace CetinFarshidfar.JewelryECommerce.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly ITagService _tagService;

        public ProductsController(IProductService productService, ICategoryService categoryService, ITagService tagService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _tagService = tagService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("/Products/Detail/{productId}")]
        public async Task<IActionResult> Detail(Guid productId)
        {
            var (isSuccess, productDetail) = await _productService.GetProductWithImagesCategoryCompanyAsync(productId);
            if(isSuccess)
                return View(productDetail);
            return NotFound();
        }
        [HttpGet]
        public async Task<JsonResult> GetProducts()
        {
            try
            {
                // Ürünleri çek
                var (isSuccess, products) = await _productService.GetAllProductsToListAsync();
                if (isSuccess)
                    return Json(new { success = true, products = products });
                return Json(new { success = false, message = "" });
            }
            catch (Exception ex)
            {
                // Hata durumunda
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllCategoriesToFilterAsync();

                return Json(new { success = true, categories });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetTags()
        {
            try
            {
                var tags = await _tagService.GetAllTagsToFilterAsync();

                return Json(new { success = true, tags });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
    }
}
