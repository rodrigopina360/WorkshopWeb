namespace Workshop.Web.Models.RequestModels
{
    public class FinishScheduleRequestModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
    }
}
