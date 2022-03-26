#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LordGrim.Data;
using LordGrim.Models;

namespace LordGrim.Pages.Grim
{
    public class EditModel : PageModel
    {
        private readonly LordGrim.Data.LordGrimContext _context;

        public EditModel(LordGrim.Data.LordGrimContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Lordgrim).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LordgrimExists(Lordgrim.ID))
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

        private bool LordgrimExists(int id)
        {
            return _context.Lordgrim.Any(e => e.ID == id);
        }
    }
}
