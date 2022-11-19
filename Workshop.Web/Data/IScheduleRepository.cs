using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Workshop.Web.Data.Entities;
using Workshop.Web.Models;

namespace Workshop.Web.Data
{
    public interface IScheduleRepository : IGenericRepository<Schedule>
    {
        Task<IEnumerable<ScheduleModel>> GetAllWithCars(string userId);

        Task<IEnumerable<ScheduleModel>> GetAllWithCars();

        Task<IEnumerable<ScheduleModel>> GetAllWithMechanic(string mechanicId);

        Task<IEnumerable<Schedule>> GetWithCarDate(int id);

        Task ConfirmScheduleAsync(Schedule schedule, string mechanicId);

        Task FinishScheduleAsync(Schedule schedule, Invoice invoice);
    }
}
