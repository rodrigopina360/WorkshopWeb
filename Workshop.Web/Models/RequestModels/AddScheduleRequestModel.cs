using System;

namespace Workshop.Web.Models.RequestModels
{
    public class AddScheduleRequestModel
    {
        public string Description { get; init; }
        public DateTime Date { get; init; }
        public int CarId { get; init; }
    }
}
