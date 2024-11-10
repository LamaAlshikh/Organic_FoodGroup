using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Organic_Food.Data;
using Organic_Food.Models;

namespace Organic_Food.Pages.OrganicFoods
{
    public class EditModel : PageModel
    {
        private readonly Organic_Food.Data.Organic_FoodContext _context;

        public EditModel(Organic_Food.Data.Organic_FoodContext context)
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

            var organicfood =  await _context.OrganicFood.FirstOrDefaultAsync(m => m.ID == id);
            if (organicfood == null)
            {
                return NotFound();
            }
            OrganicFood = organicfood;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(OrganicFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganicFoodExists(OrganicFood.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrganicFoodExists(int id)
        {
            return _context.OrganicFood.Any(e => e.ID == id);
        }
    }
}
