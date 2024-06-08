using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult ContactFormError()
        {
            return View();
        }
    }
}
