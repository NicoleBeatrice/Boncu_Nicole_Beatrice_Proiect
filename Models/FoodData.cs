namespace Boncu_Nicole_Beatrice_Proiect.Models
{
    public class FoodData
    {
        public IEnumerable<Food>? Foods { get; set; }
        public IEnumerable<Offer>? Offers { get; set; }
        public IEnumerable<FoodOffer>? FoodOffers { get; set; }
    }
}
