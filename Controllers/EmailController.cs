using Microsoft.AspNetCore.Mvc;

namespace Swarojgaar.Controllers
{
    public class EmailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
