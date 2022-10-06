using System.Linq;
using Workshop.Web.Data.Entities;

namespace Workshop.Web.Data
{
    public interface ICarRepository: IGenericRepository<Car>
    {
        public IQueryable GetAllWithUsers ();
    }
}
