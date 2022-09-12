using System;

namespace Workshop.Web.Data.Entities
{
    public class Schedule : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public Car Car { get; set; }
    }
}
