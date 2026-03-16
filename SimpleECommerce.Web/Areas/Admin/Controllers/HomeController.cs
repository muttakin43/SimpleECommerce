using Microsoft.AspNetCore.Mvc;
using SimpleECommerce.BLL.Interface;
using SimpleECommerce.BLL.Services;
using SimpleECommerce.Contract;

namespace SimpleECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryServise _categoryService;

        public HomeController(IProductService productService, ICategoryServise categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: /Admin/Home/Index
        public async Task<IActionResult> Index()
        {
            // Example: product & category count
            var products = await _productService.GetAllAsync();
            var categories = await _categoryService.GetAllAsync();

            ViewBag.ProductCount = products.Count;
            ViewBag.CategoryCount = categories.Count;

            return View();
        }
    }
}