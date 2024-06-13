using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    public class SuccessController : Controller
    {
        public IActionResult SuccessContactForm()
        {
            return View();
        }

        public IActionResult BookATableForm()
        {
            return View();
        }
    }
}
