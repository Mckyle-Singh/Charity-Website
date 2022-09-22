using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LoginSec.Controllers
{
    public class RoleController : Controller
    {
        [Authorize(Policy ="EmployeeOnly")]
        public IActionResult admin()
        {
            return View();
        }
    }
}
