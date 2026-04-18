
namespace TrainTicketsProject.Models
{

   
    public class Carriage
    {
        [Key]
        public int CarriageId { get; set; }
        public string CarriageName { get; set; } = string.Empty;
      

        public int Capacity { get; set; } = 0;
        public DateOnly CreatedAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public bool IsActive { get; set; } = true;

        public int TrainId { get; set; }
        [ForeignKey(nameof(TrainId))]
        public Train Train { get; set; } = default!;


        public int TrainClassId { get; set; }
        public TrainClass TrainClass { get; set; }= default!;



    }
}
