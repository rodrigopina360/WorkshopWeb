using System.Linq;
using Workshop.Web.Data.Entities;
using Workshop.Web.Models.ViewModels;

namespace Workshop.Web.Data
{
    public interface ICarRepository: IGenericRepository<Car>
    {
        public IQueryable GetAllWithUsers(string userId);

        public ViewCarViewModel GetViewCarData(int id);
    }
}
