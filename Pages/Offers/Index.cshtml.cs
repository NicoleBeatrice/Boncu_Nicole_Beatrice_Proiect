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
    public class IndexModel : PageModel
    {
        private readonly Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext _context;

        public IndexModel(Boncu_Nicole_Beatrice_Proiect.Data.Boncu_Nicole_Beatrice_ProiectContext context)
        {
            _context = context;
        }

        public IList<Offer> Offer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Offer != null)
            {
                Offer = await _context.Offer.ToListAsync();
            }
        }
    }
}
