using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Boncu_Nicole_Beatrice_Proiect.Data;
using Boncu_Nicole_Beatrice_Proiect.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Boncu_Nicole_Beatrice_Proiect.Pages.Foods
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : FoodOffersPageModel

    {
        private readonly Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext _context;

        public CreateModel(Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DrinkID"] = new SelectList(_context.Set<Drink>(), "ID", "DrinkName");
            var food = new Food();
            food.FoodOffers = new List<FoodOffer>();
            PopulateNewOfferData(_context, food);
            return Page();
        }

        [BindProperty]
        public Food Food { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedOffers)
        {
            var newFood = new Food();
            if (selectedOffers != null)
            {
                newFood.FoodOffers = new List<FoodOffer>();
                foreach (var cat in selectedOffers)
                {
                    var catToAdd = new FoodOffer
                    {
                        OfferID = int.Parse(cat)
                    };
                    newFood.FoodOffers.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Food>(newFood, "Food",
           i => i.Name, i => i.Allergens,
            i => i.Price, i => i.ExtraToppings, i => i.Drink))
            {
                _context.Food.Add(newFood);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            PopulateNewOfferData(_context, newFood);
            return Page();
        }
    }
}
