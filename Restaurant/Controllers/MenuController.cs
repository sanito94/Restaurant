using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Contracts;
using Restaurant.Core.Models.Menu;
using Restaurant.Core.Services;

namespace Restaurant.Controllers
{
    public class MenuController : Controller
    {

        private readonly IAdminService adminService;

        public MenuController(IAdminService _adminService)
        {
            adminService = _adminService;
        }

        public async Task<IActionResult> Menu(ShopQueryModel model)
        {
            var shopCategories = await adminService.AllCategoriesAsync();
            var shopItems = await adminService.AllItemsAsync();

            model.Category = shopCategories;
            model.Items = shopItems;

            return View(model);
        }

        public IActionResult Details()
        {
            return View();
        }
    }
}
