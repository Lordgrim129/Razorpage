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
    public class IndexModel : PageModel
    {
        private readonly LordGrim.Data.LordGrimContext _context;

        public IndexModel(LordGrim.Data.LordGrimContext context)
        {
            _context = context;
        }

        public IList<Lordgrim> Lordgrim { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string LordgrimGenre { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            IQueryable<string> genreQuery = from m in _context.Lordgrim
                                            orderby m.Genre
                                            select m.Genre;

            var Lordgrims = from m in _context.Lordgrim
                         select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                Lordgrims = Lordgrims.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(LordgrimGenre))
            {
                Lordgrims = Lordgrims.Where(x => x.Genre == LordgrimGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Lordgrim = await Lordgrims.ToListAsync();
      
        }
    }
}
