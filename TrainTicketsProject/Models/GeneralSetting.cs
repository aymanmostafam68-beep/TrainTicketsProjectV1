namespace TrainTicketsProject.Models
{
    public class GeneralSetting
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string logoName { get; set; } = string.Empty;
        public string logoUrl { get; set; } = string.Empty;

        public int LocationId { get; set; } = 0;
        public decimal PricePerKilometer { get; set; } = 0;
    
    }
}
