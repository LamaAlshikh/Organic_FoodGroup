using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Organic_Food.Data;
using Organic_Food.Models;

namespace Organic_Food.Pages.OrganicFoods
{
    public class IndexModel : PageModel
    {
        private readonly Organic_Food.Data.Organic_FoodContext _context;

        public IndexModel(Organic_Food.Data.Organic_FoodContext context)
        {
            _context = context;
        }

        public IList<OrganicFood> OrganicFood { get;set; } = default!;

        public async Task OnGetAsync()
        {
            OrganicFood = await _context.OrganicFood.ToListAsync();
        }
    }
}
