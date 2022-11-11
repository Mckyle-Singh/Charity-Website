using Microsoft.AspNetCore.Mvc;

namespace LoginSec.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
