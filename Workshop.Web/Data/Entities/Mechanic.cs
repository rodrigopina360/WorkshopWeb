namespace Workshop.Web.Data.Entities
{
    public class Mechanic
    {
        public int Id { get; set; }
        public int EnterHour { get; set; }
        public int EnterMinute { get; set; }
        public int LeaveHour { get; set; }
        public int LeaveMinute { get; set; }
        public User User { get; set; }
    }
}
