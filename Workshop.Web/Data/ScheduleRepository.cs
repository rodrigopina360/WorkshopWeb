using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Web.Data.Entities;
using Workshop.Web.Models;

namespace Workshop.Web.Data
{
    public class ScheduleRepository : GenericRepository<Schedule>, IScheduleRepository
    {
        readonly DataContext _context;
        readonly IInvoiceRepository _invoiceRepository;
        public ScheduleRepository (DataContext context, IInvoiceRepository invoiceRepository) : base(context)
        {
            _context = context;
            _invoiceRepository = invoiceRepository;
        }

        public async Task ConfirmScheduleAsync(Schedule schedule, string mechanicId)
        {
            schedule.IsConfirmed = true;
            schedule.MechanicId = mechanicId;
            await UpdateAsync(schedule);
        }

        public async Task FinishScheduleAsync(Schedule schedule, Invoice invoice)
        {
            await _invoiceRepository.CreateAsync(invoice);
            await DeleteAsync(schedule);
        }

        public async Task<IEnumerable<ScheduleModel>> GetAllWithCars(string userId)
        {
            return await _context.Schedules
                .Where(s => s.Car.User.Id == userId)
                .Select(s => new ScheduleModel
                {
                    Id = s.Id,
                    Description = s.Description,
                    StartDate = s.StartDate,
                    IsConfirmed = s.IsConfirmed,
                    Car = new CarModel
                    {
                        Id = s.Car.Id,
                        Brand = s.Car.Brand,
                        Model = s.Car.Model,
                        Year = s.Car.Year,
                    },
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ScheduleModel>> GetAllWithCars()
        {
            return await _context.Schedules
                .Select(s => new ScheduleModel
                {
                    Id = s.Id,
                    Description = s.Description,
                    StartDate = s.StartDate,
                    IsConfirmed = s.IsConfirmed,
                    Car = new CarModel
                    {
                        Id = s.Car.Id,
                        Brand = s.Car.Brand,
                        Model = s.Car.Model,
                        Year = s.Car.Year,
                    },
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ScheduleModel>> GetAllWithMechanic(string mechanicId)
        {
            return await _context.Schedules
                .Where(s => s.MechanicId == mechanicId)
                .Select(s => new ScheduleModel
                {
                    Id = s.Id,
                    Description = s.Description,
                    StartDate = s.StartDate,
                    IsConfirmed = s.IsConfirmed,
                    Car = new CarModel
                    {
                        Id = s.Car.Id,
                        Brand = s.Car.Brand,
                        Model = s.Car.Model,
                        Year = s.Car.Year,
                    },
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<Schedule>> GetWithCarDate(int id)
        {
            return await _context.Schedules
                .Where(s => s.Id == id)
                .Select(s => new Schedule
                {
                    Id = s.Id,
                    Description = s.Description,
                    StartDate = s.StartDate,
                    IsConfirmed = s.IsConfirmed,
                    Car = s.Car,
                })
                .ToListAsync();
        }
    }
}
