namespace TrainTicketsProject.Models
{
    public class TripDirection
    {
        public int TripDirectionId { get; set; }

        public int TripScheduleId { get; set; }
        public TripSchedule TripSchedule { get; set; } = default!;

        public int FromStationId { get; set; }
        public Station FromStation { get; set; } = default!;

        public int ToStationId { get; set; }
        public Station ToStation { get; set; } = default!;
    }
}
