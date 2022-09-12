namespace Workshop.Web.Data.Entities
{
    public class UserType : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
