namespace Workshop.Web.Models
{
    public class CarViewModel
    {
        public int Id { get; init; }
        public string Brand { get; init; }
        public string Model { get; init; }
        public string CarName => Brand + " " + Model;
    }
}
