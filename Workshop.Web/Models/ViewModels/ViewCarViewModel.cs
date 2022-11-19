using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workshop.Web.Models.ViewModels
{
    public class ViewCarViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public string ImagePath { get; set; }
        public List<ViewInvoiceViewModel> Invoice { get; set; }
        public string Name => Brand + " " + Model + " " + Year;
    }
}
