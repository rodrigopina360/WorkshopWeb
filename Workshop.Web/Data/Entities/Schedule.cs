using System;

namespace Workshop.Web.Data.Entities
{
    public class Schedule : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsConfirmed { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public string MechanicId { get; set; }
        public User Mechanic { get; set; }
    }
}
