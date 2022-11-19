namespace Workshop.Web.Data.Entities
{
    public class Mechanic : IEntity
    {
        public int Id { get; set; }
        public int EnterHour { get; set; }
        public int EnterMinute { get; set; }
        public int LeaveHour { get; set; }
        public int LeaveMinute { get; set; }
        public User User { get; set; }
        public string EnterTime => string.Format("{0:00}:{1:00}", EnterHour, EnterMinute);
        public string LeaveTime => string.Format("{0:00}:{1:00}", LeaveHour, LeaveMinute);
    }
}
