using System;

namespace Workshop.Web.Models
{
    public class ScheduleModel
    {
        public int Id { get; init; }
        public string Description { get; init; }
        public DateTime StartDate { get; init; }
        public decimal Price { get; init; }
        public bool IsConfirmed { get; set; }
        public CarModel Car { get; set; }

    }
}
