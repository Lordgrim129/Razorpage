#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LordGrim.Data;
using LordGrim.Models;

namespace LordGrim.Pages.Grim
{
    public class DeleteModel : PageModel
    {
        private readonly LordGrim.Data.LordGrimContext _context;

        public DeleteModel(LordGrim.Data.LordGrimContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Lordgrim Lordgrim { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lordgrim = await _context.Lordgrim.FirstOrDefaultAsync(m => m.ID == id);

            if (Lordgrim == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Lordgrim = await _context.Lordgrim.FindAsync(id);

            if (Lordgrim != null)
            {
                _context.Lordgrim.Remove(Lordgrim);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
