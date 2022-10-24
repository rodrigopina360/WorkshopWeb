using Microsoft.AspNetCore.Mvc;

namespace Workshop.Web.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index ()
        {
            return View();
        }
    }
}
