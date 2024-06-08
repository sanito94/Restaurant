using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Restaurant.Core.Constants.RoleConstants;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = AdminRole)]
    public class AdminBaseController : Controller
    {

    }
}
