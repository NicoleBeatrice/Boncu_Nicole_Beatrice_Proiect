using Boncu_Nicole_Beatrice_Proiect.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Boncu_Nicole_Beatrice_Proiect.Pages.Foods
{
    [Authorize(Roles = "Admin")]
    public class EditModel : FoodOffersPageModel
    {
        private readonly Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext _context;

        public EditModel(Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Food Food { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Food = await _context.Food
                .Include(b => b.Drink)
                .Include(b => b.FoodOffers).ThenInclude(b => b.Offer)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            var food = await _context.Food.FirstOrDefaultAsync(m => m.ID == id);
            if (food == null)
            {
                return NotFound();
            }

            PopulateNewOfferData(_context, Food);
            ViewData["DrinkID"] = new SelectList(_context.Set<Drink>(), "ID", "DrinkName");
            
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult>  OnPostAsync(int? id, string[]selectedOffers)
        {
            if (id == null)
            {
                return NotFound();
            }
            var foodToUpdate = await _context.Food
            .Include(i => i.Drink)
            .Include(i => i.FoodOffers)
            .ThenInclude(i => i.Offer)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (foodToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Food>( foodToUpdate, "Food",  i => i.Name, i => i.Allergens,
            i => i.Price, i => i.ExtraToppings, i => i.Drink))
            {
                UpdateFoodOffers(_context, selectedOffers, foodToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateFoodOffers pentru a aplica informatiile din checkboxuri la entitatea Foods care
            //este editata
            UpdateFoodOffers(_context, selectedOffers, foodToUpdate);
            PopulateNewOfferData(_context, foodToUpdate);
            return Page();
        }
    }
}