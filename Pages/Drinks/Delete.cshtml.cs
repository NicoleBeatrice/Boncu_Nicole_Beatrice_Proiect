using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Boncu_Nicole_Beatrice_Proiect.Data;
using Boncu_Nicole_Beatrice_Proiect.Models;

namespace Boncu_Nicole_Beatrice_Proiect.Pages.Drinks
{
    public class DeleteModel : PageModel
    {
        private readonly Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext _context;

        public DeleteModel(Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Drink Drink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Drink == null)
            {
                return NotFound();
            }

            var drink = await _context.Drink.FirstOrDefaultAsync(m => m.ID == id);

            if (drink == null)
            {
                return NotFound();
            }
            else 
            {
                Drink = drink;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Drink == null)
            {
                return NotFound();
            }
            var drink = await _context.Drink.FindAsync(id);

            if (drink != null)
            {
                Drink = drink;
                _context.Drink.Remove(Drink);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
