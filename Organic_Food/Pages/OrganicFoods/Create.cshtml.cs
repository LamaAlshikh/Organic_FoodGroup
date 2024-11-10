using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Organic_Food.Data;
using Organic_Food.Models;

namespace Organic_Food.Pages.OrganicFoods
{
    public class CreateModel : PageModel
    {
        private readonly Organic_Food.Data.Organic_FoodContext _context;

        public CreateModel(Organic_Food.Data.Organic_FoodContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public OrganicFood OrganicFood { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.OrganicFood.Add(OrganicFood);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
