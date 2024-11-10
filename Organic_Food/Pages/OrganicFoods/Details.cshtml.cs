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
    public class DetailsModel : PageModel
    {
        private readonly Organic_Food.Data.Organic_FoodContext _context;

        public DetailsModel(Organic_Food.Data.Organic_FoodContext context)
        {
            _context = context;
        }

        public OrganicFood OrganicFood { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organicfood = await _context.OrganicFood.FirstOrDefaultAsync(m => m.ID == id);
            if (organicfood == null)
            {
                return NotFound();
            }
            else
            {
                OrganicFood = organicfood;
            }
            return Page();
        }
    }
}
