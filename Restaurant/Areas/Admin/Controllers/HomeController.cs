﻿using Microsoft.AspNetCore.Mvc;

namespace Restaurant.Areas.Admin.Controllers
{
    public class HomeController : AdminBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
