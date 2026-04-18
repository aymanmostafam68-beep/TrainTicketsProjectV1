namespace TrainTicketsProject.Models
{
    public class TripDirection
    {
        [Key]
        public int TripDirectionId { get; set; }
        public int TripScheduleId { get; set; }
        [ForeignKey(nameof(TripScheduleId))]
        public TripSchedule TripSchedule { get; set; } = default!;


        public int FromStationId { get; set; }
        [ForeignKey(nameof(FromStationId))]

        public Station FromStation { get; set; } = default!;

        public int ToStationId { get; set; }
        [ForeignKey(nameof(ToStationId))]
        public Station ToStation { get; set; } = default!;

    }
}
