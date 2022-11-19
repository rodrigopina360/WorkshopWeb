using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Workshop.Web.Data;
using Workshop.Web.Data.Entities;
using Workshop.Web.Helpers;

namespace Workshop.Web.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommunicationController : Controller
    {
        readonly IUserHelper _userHelper;
        readonly IMailHelper _mailHelper;

        public CommunicationController(IUserHelper userHelper, IMailHelper mailHelper)
        {
            _userHelper = userHelper;
            _mailHelper = mailHelper;
        }

        [HttpPost]
        public async Task CloseWorkshop()
        {
            var users = await _userHelper.GetAllUsersAsync();

            foreach (User user in users)
            {
                if (user.EmailConfirmed)
                {
                    _mailHelper.SendEmail(user.Email, "Workshop Unexpectedly Closed", "We are sorry to inform, but Workshop will be closed today due to internal issues!");
                }
                
            }
        }
    }
}
