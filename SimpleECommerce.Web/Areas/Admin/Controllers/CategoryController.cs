using Microsoft.AspNetCore.Mvc;
using SimpleECommerce.BLL.Interface;
using SimpleECommerce.BLL.Services;
using SimpleECommerce.Contract;

namespace SimpleECommerce.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryServise _categoryService;
        public CategoryController(ICategoryServise categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index() => View(await _categoryService.GetAllAsync());
        public async Task<IActionResult> Details(Guid id) => View(await _categoryService.GetByIdAsync(id));
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);
            await _categoryService.CreateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id) => View(await _categoryService.GetByIdAsync(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryDTO dto)
        {
            if (!ModelState.IsValid) return View(dto);
            await _categoryService.UpdateAsync(dto);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id) => View(await _categoryService.GetByIdAsync(id));

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _categoryService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}