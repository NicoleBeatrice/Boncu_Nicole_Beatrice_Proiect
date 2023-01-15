using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Boncu_Nicole_Beatrice_Proiect.Data;
using Boncu_Nicole_Beatrice_Proiect.Models;

namespace Boncu_Nicole_Beatrice_Proiect.Pages.Foods
{

    public class IndexModel : PageModel
    {
        private readonly Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext _context;

        public IndexModel(Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get; set; } = default!;
        public FoodData FoodD { get; set; }
        public int FoodID { get; set; }
        public int OfferID { get; set; }
        public async Task OnGetAsync(int? id, int? offerID)
        {
            FoodD = new FoodData();

            FoodD.Foods = await _context.Food
            .Include(b => b.Drink)
            .Include(b => b.FoodOffers)
            .ThenInclude(b => b.Offer)
            .AsNoTracking()
            .OrderBy(b => b.Name)
            .ToListAsync();
            if (id != null)
            {
                FoodID = id.Value;
                Food food = FoodD.Foods
                .Where(i => i.ID == id.Value).Single();
                FoodD.Offers = food.FoodOffers.Select(s => s.Offer);
            }
        }
    }
}