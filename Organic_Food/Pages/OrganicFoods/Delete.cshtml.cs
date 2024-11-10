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
    public class DeleteModel : PageModel
    {
        private readonly Organic_Food.Data.Organic_FoodContext _context;

        public DeleteModel(Organic_Food.Data.Organic_FoodContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organicfood = await _context.OrganicFood.FindAsync(id);
            if (organicfood != null)
            {
                OrganicFood = organicfood;
                _context.OrganicFood.Remove(OrganicFood);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
