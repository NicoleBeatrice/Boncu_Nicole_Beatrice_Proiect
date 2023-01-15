using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Boncu_Nicole_Beatrice_Proiect.Models;

namespace Boncu_Nicole_Beatrice_Proiect.Data
{
    public class Boncu_Nicole_Beatrice_ProiectContext : DbContext
    {
        public Boncu_Nicole_Beatrice_ProiectContext (DbContextOptions<Boncu_Nicole_Beatrice_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Boncu_Nicole_Beatrice_Proiect.Models.Food> Food { get; set; } = default!;

        public DbSet<Boncu_Nicole_Beatrice_Proiect.Models.Drink> Drink { get; set; }

        public DbSet<Boncu_Nicole_Beatrice_Proiect.Models.Offer> Offer { get; set; }

        public DbSet<Boncu_Nicole_Beatrice_Proiect.Models.User> User { get; set; }

       
    }
}
