using Microsoft.EntityFrameworkCore;
using System.Linq;
using Workshop.Web.Data.Entities;

namespace Workshop.Web.Data
{
    public class CarRepository: GenericRepository<Car>, ICarRepository
    {
        private readonly DataContext _context;
        public CarRepository (DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers ()
        {
            return _context.Cars.Include(p => p.User);
        }
    }
}
