using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workshop.Web.Data.Entities;
using Workshop.Web.Models;

namespace Workshop.Web.Data
{
    public class InvoiceRepository : GenericRepository<Invoice>, IInvoiceRepository
    {
        private readonly DataContext _context;
        public InvoiceRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetAllCarInvoices(int carId)
        {
            return await _context.Invoices
                .Where(s => s.CarId == carId)
                .Select(s => new Invoice
                {
                    Id = s.Id,
                    Description = s.Description,
                    Price = s.Price,
                    CarId = carId,
                }).ToListAsync();
        }
    }
}
