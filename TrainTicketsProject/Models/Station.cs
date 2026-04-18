namespace TrainTicketsProject.Models
{
    public class Station
    {
        [Key]

        public int StationId { get; set; }
        public string StationName { get; set; } = string.Empty;

        public string StationDescription { get; set; } = string.Empty;

        public string StationLogoName { get; set; } = string.Empty;
        public string StationLogoUrl { get; set; } = string.Empty;
        public decimal DistanceFromCentral { get; set; } = 0;

        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public bool IsActive { get; set; } = true;

    }
}

