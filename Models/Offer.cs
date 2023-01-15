namespace Boncu_Nicole_Beatrice_Proiect.Models
{
    public class Offer
    {
        public int ID { get; set; }
        public string? Oferta { get; set; }
        public ICollection<FoodOffer>? FoodOffers { get; set; }
    }
}
