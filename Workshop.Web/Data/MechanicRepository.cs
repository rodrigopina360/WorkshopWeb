using Microsoft.EntityFrameworkCore;
using System.Linq;
using Workshop.Web.Data.Entities;

namespace Workshop.Web.Data
{
    public class MechanicRepository: GenericRepository<Mechanic>, IMechanicRepository
    {
        private readonly DataContext _context;
        public MechanicRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUsers ()
        {
            return _context.Mechanics.Include(p => p.User);
        }
    }
}
