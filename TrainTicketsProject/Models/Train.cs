namespace TrainTicketsProject.Models
{
    public class Train
    {
        [Key]

        public int TrainId { get; set; }
        public string TrainName { get; set; } = string.Empty;
        public int Capacity { get; set; } = 0;
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public bool IsActive { get; set; } = true;

        public int RouteId { get; set; }
        [ForeignKey(nameof(RouteId))]
        public Route Route { get; set; } = default!;

        public ICollection<Carriage> Carriages { get; set; } = new List<Carriage>();

    }
}
