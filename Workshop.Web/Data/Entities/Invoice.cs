namespace Workshop.Web.Data.Entities
{
    public class Invoice : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CarId { get; set; }
    }
}
