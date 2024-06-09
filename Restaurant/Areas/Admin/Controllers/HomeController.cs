using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Contracts;
using Restaurant.Core.Models.Admin;

namespace Restaurant.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        private readonly IAdminService adminService;

        public HomeController(IAdminService _adminService)
        {
            adminService = _adminService;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult AddCategory()
        {
            var model = new CategoryServiceModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var categoryExist = await adminService.CategoryExistsByNameAsync(model.Name);

            if (categoryExist == true)
            {
                return BadRequest();
            }

            await adminService.AddCategoryAsync(model.Name);

            return RedirectToAction(nameof(Dashboard));
        }

        public async Task<IActionResult> AddItem()
        {
            var model = new ItemServiceModel();

            model.Category = await adminService.AllCategoriesAsync();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ItemServiceModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Category = await adminService.AllCategoriesAsync();

                return View(model);
            }

            var itemExist = await adminService.ItemExistsByNameAsync(model.Name);

            if (itemExist == true)
            {
                return BadRequest();
            }

            await adminService.AddItemAsync(model);

            return RedirectToAction(nameof(Dashboard));
        }
    }
}
