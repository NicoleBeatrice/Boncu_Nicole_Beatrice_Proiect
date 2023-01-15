namespace Boncu_Nicole_Beatrice_Proiect.Models
{
    public class Drink
    {
       
        public int ID { get; set; }
        public string? DrinkName { get; set; }
        public ICollection<Food>? Foods { get; set; } //navigation property
    }
}
