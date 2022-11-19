using System.Linq;
using Workshop.Web.Data.Entities;

namespace Workshop.Web.Data
{
    public interface IMechanicRepository : IGenericRepository<Mechanic>
    {
        public IQueryable GetAllWithUsers();
    }
}
