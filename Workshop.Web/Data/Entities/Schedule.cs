using System;

namespace Workshop.Web.Data.Entities
{
    public class Schedule : IEntity
    {
        public int Id { get; set; }
        public string Descripton { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Price { get; set; }
        public bool IsConfirmed { get; set; }
        public Car Car { get; set; }
    }
}
