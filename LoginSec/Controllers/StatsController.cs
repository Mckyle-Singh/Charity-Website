using Microsoft.AspNetCore.Mvc;

namespace LoginSec.Controllers
{
    public class StatsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
