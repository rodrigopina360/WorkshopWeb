using Microsoft.AspNetCore.Mvc;
using Workshop.Web.Data;

namespace Workshop.Web.Controllers
{
    public class ScheduleController : Controller
    {
        readonly ICarRepository _carRepository;
        readonly IScheduleRepository _scheduleRepository;

        public ScheduleController(ICarRepository carRepository, IScheduleRepository scheduleRepository)
        {
            _carRepository = carRepository;
            _scheduleRepository = scheduleRepository;
        }

        public IActionResult Index ()
        {
            return View();
        }

        /*public JsonResult GetEvents ()
        {
            var events = _scheduleRepository.GetAllWithCars();

        }*/
    }
}
