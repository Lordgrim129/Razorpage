#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LordGrim.Data;
using LordGrim.Models;

namespace LordGrim.Pages.Grim
{
    public class CreateModel : PageModel
    {
        private readonly LordGrim.Data.LordGrimContext _context;

        public CreateModel(LordGrim.Data.LordGrimContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Lordgrim Lordgrim { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Lordgrim.Add(Lordgrim);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
