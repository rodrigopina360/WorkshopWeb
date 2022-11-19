using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Workshop.Web.Data;

namespace Workshop.Web.Controllers.API
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InvoiceController : Controller
    {
        readonly IInvoiceRepository _invoiceRepository;

        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetInvoices(int carId)
        {
            return Ok(await _invoiceRepository.GetAllCarInvoices(carId));
        }
    }
}
