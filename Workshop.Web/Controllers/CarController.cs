using Microsoft.AspNetCore.Mvc;
using Workshop.Web.Data;
using Workshop.Web.Data.Entities;
using Workshop.Web.Models.ViewModels;

namespace Workshop.Web.Controllers
{
    public class CarController : Controller
    {
        readonly ICarRepository _carRepository;

        public CarController (ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public IActionResult Index()
        {
            var cars = _carRepository.GetAllWithUsers();
            return View(cars);
        }

        public IActionResult AddCar()
        {
            return View();
        }
    }
}
