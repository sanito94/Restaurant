using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    public class MenuController : Controller
    {
        public IActionResult FirstItem()
        {
            return View();
        }
    }
}
