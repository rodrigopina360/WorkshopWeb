using Microsoft.AspNetCore.Identity;
using Workshop.Web.Data.Entities;
using System.Threading.Tasks;

namespace Workshop.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
    }
}
