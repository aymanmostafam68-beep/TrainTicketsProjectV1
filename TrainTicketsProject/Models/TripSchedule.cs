namespace TrainTicketsProject.Models
{
    public class TripSchedule
    {
        public int TripScheduleId { get; set; }

        public int RouteId { get; set; }
        [ForeignKey(nameof(RouteId))]
        public Route Route { get; set; } = default!;


        public int TrainId { get; set; }
        [ForeignKey(nameof(TrainId))]
        public Train Train { get; set; } = default!;

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public bool IsActive { get; set; }



    }
}
