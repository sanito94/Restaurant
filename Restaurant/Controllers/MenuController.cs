using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.Contracts;
using Restaurant.Core.Models.Menu;
using Restaurant.Core.Services;

namespace Restaurant.Controllers
{
    public class MenuController : Controller
    {

        private readonly IAdminService adminService;
        private readonly IMenuService menuService;

        public MenuController(
            IAdminService _adminService,
            IMenuService _menuService
            )
        {
            adminService = _adminService;
            menuService = _menuService;
        }

        public async Task<IActionResult> Menu(ShopQueryModel model)
        {
            var shopCategories = await adminService.AllCategoriesAsync();
            var shopItems = await adminService.AllItemsAsync();

            model.Category = shopCategories;
            model.Items = shopItems;

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await menuService.ItemDetailsByIdAsync(id);

            return View(item);
        }
    }
}
