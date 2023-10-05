using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetsApp2.Data;
using PetsApp2.Models;

namespace PetsApp2.Pages.Cats
{
    public class EditModel : PageModel
    {
        private readonly PetsApp2.Data.PetsApp2Context _context;

        public EditModel(PetsApp2.Data.PetsApp2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Cat Cat { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cat == null)
            {
                return NotFound();
            }

            var cat =  await _context.Cat.FirstOrDefaultAsync(m => m.CatId == id);
            if (cat == null)
            {
                return NotFound();
            }
            Cat = cat;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Cat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatExists(Cat.CatId))
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

        private bool CatExists(int id)
        {
          return (_context.Cat?.Any(e => e.CatId == id)).GetValueOrDefault();
        }
    }
}
