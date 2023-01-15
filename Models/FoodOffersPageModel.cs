using Microsoft.AspNetCore.Mvc.RazorPages;
using Boncu_Nicole_Beatrice_Proiect.Data;

namespace Boncu_Nicole_Beatrice_Proiect.Models
{
    public class FoodOffersPageModel:PageModel
 {
        public List<NewOfferData>? NewOfferDataList;
        public void PopulateNewOfferData(Boncu_Nicole_Beatrice_ProiectContext context, Food food)
        {
            var allOffers = context.Offer;
            var foodOffers = new HashSet<int>( food.FoodOffers.Select(c => c.OfferID)); 
            NewOfferDataList = new List<NewOfferData>();
            foreach (var cat in allOffers)
            {
                NewOfferDataList.Add(new NewOfferData
                {
                    OfferID = cat.ID,
                    Name = cat.Oferta,
                    New = foodOffers.Contains(cat.ID)
                });
            }
        }
        public void UpdateFoodOffers(Boncu_Nicole_Beatrice_ProiectContext context,
        string[] selectedOffers, Food foodToUpdate)
        {
            if (selectedOffers == null)
            {
                foodToUpdate.FoodOffers = new List<FoodOffer>();
                return;
            }
            var selectedOffersHS = new HashSet<string>(selectedOffers);
            var foodOffers = new HashSet<int>
            (foodToUpdate.FoodOffers.Select(c => c.Offer.ID));
            foreach (var cat in context.Offer)
            {
                if (selectedOffersHS.Contains(cat.ID.ToString()))
                {
                    if (!foodOffers.Contains(cat.ID))
                    {
                        foodToUpdate.FoodOffers.Add(
                        new FoodOffer
                        {
                            FoodID = foodToUpdate.ID,
                            OfferID = cat.ID
                        });
                    }
                }
                else
                {
                    if (foodOffers.Contains(cat.ID))
                    {
                        FoodOffer courseToRemove
                        = foodToUpdate
                        .FoodOffers
                        .SingleOrDefault(i => i.OfferID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }

}
