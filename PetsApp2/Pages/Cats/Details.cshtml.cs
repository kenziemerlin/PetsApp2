using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PetsApp2.Data;
using PetsApp2.Models;

namespace PetsApp2.Pages.Cats
{
    public class DetailsModel : PageModel
    {
        private readonly PetsApp2.Data.PetsApp2Context _context;

        public DetailsModel(PetsApp2.Data.PetsApp2Context context)
        {
            _context = context;
        }

      public Cat Cat { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cat == null)
            {
                return NotFound();
            }

            var cat = await _context.Cat.FirstOrDefaultAsync(m => m.CatId == id);
            if (cat == null)
            {
                return NotFound();
            }
            else 
            {
                Cat = cat;
            }
            return Page();
        }
    }
}
