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


//Build an Expense Tracker with Asp.Net Core MVC. 2022. YouTube video, added by CodeAffection. [Online]. Available at: 
//https://youtu.be/zQ5eijfpuu8 [Accessed 10 October 2022]