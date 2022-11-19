using Microsoft.EntityFrameworkCore;
using System.Linq;
using Workshop.Web.Data.Entities;
using Workshop.Web.Models.ViewModels;

namespace Workshop.Web.Data
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly DataContext _context;
        public CarRepository (DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers(string userId)
        {
            return _context.Cars
                .Where(p => p.UserId == userId);
        }

        public ViewCarViewModel GetViewCarData(int id)
        {
            var car = _context.Cars
                .Where(c => c.Id == id)
                .Select(c => new ViewCarViewModel
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Year = c.Year,
                    LicensePlate = c.LicensePlate,
                    ImagePath = c.ImagePath,
                }).ToListAsync().Result.FirstOrDefault();

            car.Invoice = _context.Invoices
                .Where(i => i.CarId == car.Id)
                .Select(i => new ViewInvoiceViewModel
                {
                    Description = i.Description,
                    Price = i.Price,
                }).ToListAsync().Result;

            return car;
        }
    }
}
