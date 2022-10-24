using System;

namespace Workshop.Web.Models
{
    public class ScheduleViewModel
    {
        public int Id { get; init; }
        public string Description { get; init; }
        public DateTime StartDate { get; init; }
        public decimal Price { get; init; }
        public CarViewModel Car { get; set; }

    }
}
