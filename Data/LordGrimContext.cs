#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LordGrim.Models;

namespace LordGrim.Data
{
    public class LordGrimContext : DbContext
    {
        public LordGrimContext (DbContextOptions<LordGrimContext> options)
            : base(options)
        {
        }

        public DbSet<LordGrim.Models.Lordgrim> Lordgrim { get; set; }
    }
}
