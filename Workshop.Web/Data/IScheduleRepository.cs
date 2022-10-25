using System.Collections.Generic;
using System.Threading.Tasks;
using Workshop.Web.Data.Entities;
using Workshop.Web.Models;

namespace Workshop.Web.Data
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
        Task<IEnumerable<ScheduleModel>> GetAllWithCars (string userId);

        Task<IEnumerable<ScheduleModel>> GetAllWithCars ();
    }
}
