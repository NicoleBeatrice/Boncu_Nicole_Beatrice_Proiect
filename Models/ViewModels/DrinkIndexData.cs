using System.Security.Policy;

namespace Boncu_Nicole_Beatrice_Proiect.Models.ViewModels
{
    public class DrinkIndexData
    {
        public IEnumerable<Drink>Drinks { get; set; }
        public IEnumerable<Food> Foods { get; set; }

    }
}
