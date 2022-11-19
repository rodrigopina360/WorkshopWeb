using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Web.Data;
using Workshop.Web.Data.Entities;
using Workshop.Web.Helpers;
using Workshop.Web.Models.RequestModels;

namespace Workshop.Web.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ScheduleController : Controller
    {
        readonly IScheduleRepository _scheduleRepository;
        readonly IUserHelper _userHelper;
        readonly ICarRepository _carRepository;

        public ScheduleController(IScheduleRepository scheduleRepository, IUserHelper userHelper, ICarRepository carRepository)
        {
            _scheduleRepository = scheduleRepository;
            _userHelper = userHelper;
            _carRepository = carRepository;
        }

        [HttpPost]
        public async Task<IActionResult> GetSchedules(GetSchedulesRequestModel model)
        {
            var user = await _userHelper.GetUserByEmailAsync(model.UserEmail);

            return Ok(await _scheduleRepository.GetAllWithCars(user.Id));
        }

        [HttpPost]
        public async Task<IActionResult> GetWorkerSchedules()
        {
            return Ok(await _scheduleRepository.GetAllWithCars());
        }

        [HttpPost]
        public async Task<IActionResult> GetMechanicSchedules(GetSchedulesRequestModel model)
        {
            var user = await _userHelper.GetUserByEmailAsync(model.UserEmail);

            return Ok(await _scheduleRepository.GetAllWithMechanic(user.Id));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveSchedule(GetCarScheduleDateRequestModel model)
        {
            var schedule = await _scheduleRepository.GetWithCarDate(model.Id);

            await _scheduleRepository.DeleteAsync(schedule.First());

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddSchedule(AddScheduleRequestModel model)
        {
            await _scheduleRepository.CreateAsync(new Schedule
            {
                Description = model.Description,
                StartDate = model.Date,
                IsConfirmed = false,
                CarId = model.CarId,
            });

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> ConfirmSchedule(ConfirmScheduleRequestModel model)
        {
            var schedule = await _scheduleRepository.GetWithCarDate(model.Id);

            await _scheduleRepository.ConfirmScheduleAsync(schedule.First(), model.UserId);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> FinishSchedule(FinishScheduleRequestModel model)
        {
            var schedule = await _scheduleRepository.GetWithCarDate(model.Id);

            var user = await _userHelper.GetUserByEmailAsync(model.UserId);

            var invoice = new Invoice
            {
                Description = model.Description,
                Price = model.Price,
                CarId = model.Id,
            };

            await _scheduleRepository.FinishScheduleAsync(schedule.First(), invoice);

            return Ok();
        }
    }
}
