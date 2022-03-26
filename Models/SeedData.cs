using Microsoft.EntityFrameworkCore;
using LordGrim.Data;
namespace LordGrim.Models
{
    public class SeedData
    {
   



        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LordGrimContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LordGrimContext>>()))
            {
                if (context == null || context.Lordgrim == null)
                {
                    throw new ArgumentNullException("Null LordGrimContext");
                }

                // Look for any Lordgrims.
                if (context.Lordgrim.Any())
                {
                    return;   // DB has been seeded
                }

                context.Lordgrim.AddRange(
                    new Lordgrim
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "R"
                    },

                    new Lordgrim
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "R"
                    },

                    new Lordgrim
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "R"
                    },

                    new Lordgrim
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "R"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}