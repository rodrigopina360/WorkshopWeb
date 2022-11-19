using System.Collections.Generic;
using System.Threading.Tasks;
using Workshop.Web.Data.Entities;

namespace Workshop.Web.Data
{
    public interface IInvoiceRepository : IGenericRepository<Invoice>
    {
        Task<IEnumerable<Invoice>> GetAllCarInvoices(int carId);
    }
}
