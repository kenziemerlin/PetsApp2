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
    public class IndexModel : PageModel
    {
        private readonly PetsApp2.Data.PetsApp2Context _context;

        public IndexModel(PetsApp2.Data.PetsApp2Context context)
        {
            _context = context;
        }

        public IList<Cat> Cat { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Cat != null)
            {
                Cat = await _context.Cat.ToListAsync();
            }
        }
    }
}
