namespace Boncu_Nicole_Beatrice_Proiect.Models
{
    public class NewOfferData
    {
        public int OfferID { get; set; }
        public string? Name { get; set; }
        public bool New { get; set; }
        public ICollection<Food>? Foods { get; set; } //navigation property
    }
}
