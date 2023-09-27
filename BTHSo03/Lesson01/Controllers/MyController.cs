using Microsoft.AspNetCore.Mvc;

namespace Lesson01.Controllers
{
    public class MyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
