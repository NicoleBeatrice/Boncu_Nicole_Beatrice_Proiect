using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Boncu_Nicole_Beatrice_Proiect.Models
{
    public class Food
    {
        public int ID { get; set; }

        [Display(Name = "Food Name")]
        public string? Name { get; set; }
        public string? Allergens { get; set; }

        [Column(TypeName = " decimal(6, 2)")]
        public decimal? Price { get; set; }
        public string? ExtraToppings { get; set; }
        public int? DrinkID { get; set; }
        public Drink? Drink { get; set; } //navigation property
        public ICollection<FoodOffer>? FoodOffers { get; set; }

    }
}
