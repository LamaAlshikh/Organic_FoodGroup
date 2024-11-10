using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Organic_Food.Models;

namespace Organic_Food.Data
{
    public class Organic_FoodContext : DbContext
    {
        public Organic_FoodContext (DbContextOptions<Organic_FoodContext> options)
            : base(options)
        {
        }

        public DbSet<Organic_Food.Models.OrganicFood> OrganicFood { get; set; } = default!;
    }
}
