using Microsoft.AspNetCore.Mvc;
using Workshop.Web.Data;

namespace Workshop.Web.Controllers
{
    public class MechanicController : Controller
    {
        readonly IMechanicRepository _mechanicRepository;

        public MechanicController(IMechanicRepository mechanicRepository)
        {
            _mechanicRepository = mechanicRepository;
        }

        public IActionResult Index()
        {
            var mechanics = _mechanicRepository.GetAllWithUsers();
            return View(mechanics);
        }
    }
}
