namespace Workshop.Web.Models
{
    public class CarModel
    {
        public int Id { get; init; }
        public string Brand { get; init; }
        public string Model { get; init; }
        public int Year { get; init; }
        public string CarName => Brand + " " + Model + " " + Year;
    }
}
