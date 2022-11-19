using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Workshop.Web.Data;
using Workshop.Web.Data.Entities;
using Workshop.Web.Helpers;
using Workshop.Web.Models.ViewModels;

namespace Workshop.Web.Controllers
{
    [Authorize(Roles = "Admin, Mechanic, Client")]
    public class CarController : Controller
    {
        readonly ICarRepository _carRepository;
        readonly IUserHelper _userHelper;
        readonly IImageHelper _imageHelper;

        public CarController(ICarRepository carRepository, IImageHelper imageHelper, IUserHelper userHelper)
        {
            _carRepository = carRepository;
            _imageHelper = imageHelper;
            _userHelper = userHelper;
        }

        public IActionResult Index()
        {
            var cars = _carRepository.GetAllWithUsers(_userHelper.GetUserByEmailAsync(User.Identity.Name).Result.Id);
            return View(cars);
        }

        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCar(AddCarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Car car = new Car
                {
                    Brand = viewModel.Brand,
                    Model = viewModel.Model,
                    Year = viewModel.Year,
                    LicensePlate = viewModel.LicensePlate,
                    UserId = _userHelper.GetUserByEmailAsync(User.Identity.Name).Result.Id,
                };

                if (viewModel.ImageFile != null)
                {
                    car.ImagePath = await _imageHelper.UploadImageAsync(viewModel.ImageFile, "cars");
                }

                await _carRepository.CreateAsync(car);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult AddRepair(int id)
        {
            return View(_carRepository.GetByIdAsync(id).Result);
        }

        public IActionResult ViewCar(int id)
        {
            var teste = _carRepository.GetViewCarData(id);

            return View(teste);
        }
    }
}
