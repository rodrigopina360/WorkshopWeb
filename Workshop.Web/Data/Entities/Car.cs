namespace Workshop.Web.Data.Entities
{
    public class Car : IEntity
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public string ImagePath { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string Name => Brand + " " + Model + " " + Year;
    }
}
