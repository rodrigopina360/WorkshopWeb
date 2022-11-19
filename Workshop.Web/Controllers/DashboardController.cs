using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Workshop.Web.Data;

namespace Workshop.Web.Controllers
{
    public class DashboardController : Controller
    {
        readonly IMechanicRepository _mechanicRepository;

        public DashboardController(IMechanicRepository mechanicRepository)
        {
            _mechanicRepository = mechanicRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var mechanics = _mechanicRepository.GetAllWithUsers();
            return View(mechanics);
        }
    }
}
