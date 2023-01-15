namespace Boncu_Nicole_Beatrice_Proiect.Models
{
    public class FoodOffer
    {
        public int ID { get; set; }
        public int FoodID { get; set; }
        public Food? Food { get; set; }
        public int OfferID { get; set; }
        public  Offer? Offer { get; set; }

    }
}
