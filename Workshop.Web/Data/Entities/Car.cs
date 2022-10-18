using System;

namespace Workshop.Web.Data.Entities
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public User User { get; set; }
    }
}
