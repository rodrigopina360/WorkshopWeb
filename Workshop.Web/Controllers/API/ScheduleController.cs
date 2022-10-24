using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Threading.Tasks;
using Workshop.Web.Data;
using Workshop.Web.Helpers;
using Workshop.Web.Models.RequestModels;

namespace Workshop.Web.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ScheduleController: Controller
    {
        readonly IScheduleRepository _scheduleRepository;
        readonly IUserHelper _userHelper;

        public ScheduleController(IScheduleRepository scheduleRepository, IUserHelper userHelper)
        {
            _scheduleRepository = scheduleRepository;
            _userHelper = userHelper;
        }

        [HttpPost]
        public async Task<IActionResult> GetSchedules(GetSchedulesRequestModel model)
        {
            var user = await _userHelper.GetUserByEmailAsync(model.UserEmail);

            return Ok(await _scheduleRepository.GetAllWithCars(user.Id));
        }
    }
}
