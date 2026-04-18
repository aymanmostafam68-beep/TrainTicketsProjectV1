namespace TrainTicketsProject.Models
{
    public class Route
    {
        //upperEgypt
        //lowerEgypt
        [Key]

        public int RouteId { get; set; }
        public string RouteName { get; set; } = string.Empty;
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public bool IsActive { get; set; } = true;

    }
}
