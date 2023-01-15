using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Boncu_Nicole_Beatrice_Proiect.Data;
using Boncu_Nicole_Beatrice_Proiect.Models;
using System.Security.Policy;
using Boncu_Nicole_Beatrice_Proiect.Models.ViewModels;

namespace Boncu_Nicole_Beatrice_Proiect.Pages.Drinks
{
    public class IndexModel : PageModel
    {
        private readonly Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext _context;

        public IndexModel(Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext context)
        {
            _context = context;
        }

        public IList<Drink> Drink { get;set; } = default!;

        public DrinkIndexData DrinkData { get; set; }
        public int DrinkID { get; set; }
        public int FoodID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            DrinkData = new DrinkIndexData();
            DrinkData.Drinks = await _context.Drink
            .Include(i => i.Foods)
            .OrderBy(i => i.DrinkName)
            .ToListAsync();
            if (id != null)
            {
                DrinkID = id.Value;
                Drink drink = DrinkData.Drinks
                .Where(i => i.ID == id.Value).Single();
                DrinkData.Foods = drink.Foods;
            }
        }
    }
}
