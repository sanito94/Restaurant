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

        public IActionResult DashBoard()
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

            var categoryExist = await adminService.ExistsByNameAsync(model.Name);

            if (categoryExist == true)
            {
                return BadRequest();
            }

            await adminService.AddCategoryAsync(model.Name);

            return RedirectToAction(nameof(DashBoard));
        }
    }
}
