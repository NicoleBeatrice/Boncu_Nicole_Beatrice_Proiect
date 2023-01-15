using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Boncu_Nicole_Beatrice_Proiect.Data;
using Boncu_Nicole_Beatrice_Proiect.Models;

namespace Boncu_Nicole_Beatrice_Proiect.Pages.Offers
{
    public class DeleteModel : PageModel
    {
        private readonly Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext _context;

        public DeleteModel(Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Offer Offer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Offer == null)
            {
                return NotFound();
            }

            var offer = await _context.Offer.FirstOrDefaultAsync(m => m.ID == id);

            if (offer == null)
            {
                return NotFound();
            }
            else 
            {
                Offer = offer;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Offer == null)
            {
                return NotFound();
            }
            var offer = await _context.Offer.FindAsync(id);

            if (offer != null)
            {
                Offer = offer;
                _context.Offer.Remove(Offer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
