using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetsApp2.Data;
using PetsApp2.Models;

namespace PetsApp2.Pages.Cats
{
    public class CreateModel : PageModel
    {
        private readonly PetsApp2.Data.PetsApp2Context _context;
        private readonly IWebHostEnvironment _env;

        [BindProperty]
        public Cat Cat { get; set; } = default!;
        [BindProperty]
        public IFormFile ImageUpload { get; set; } = default!;

        public CreateModel(PetsApp2.Data.PetsApp2Context context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            string imageFileName = DateTime.Now.ToString("yyy-MM-dd-HH-mm-ss_") + ImageUpload.FileName;
            Cat.FileName = imageFileName;

            if (!ModelState.IsValid || _context.Cat == null || Cat == null)
            {
                return Page();
            }

            _context.Cat.Add(Cat);

            await _context.SaveChangesAsync();

            string filePath = Path.Combine(_env.ContentRootPath, "wwwroot/photos", imageFileName);
            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                ImageUpload.CopyTo(fileStream);
            }
           
            return RedirectToPage("./Index");
        }
    }
}
