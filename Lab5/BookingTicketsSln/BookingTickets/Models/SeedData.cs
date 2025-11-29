using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            BookingDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider
                .GetRequiredService<BookingDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.Events.Any())
            {
                context.Events.AddRange(
                    new Event
                    {
                        Title = "Rock Festival",
                        Description = "Open-air rock fest",
                        Category = "Music",
                        Price = 120
                    },
                    new Event
                    {
                        Title = "Stand-Up Night",
                        Description = "Comedy show evening",
                        Category = "Comedy",
                        Price = 45
                    },
                    new Event
                    {
                        Title = "Jazz Evening",
                        Description = "Smooth jazz performance in a cozy hall",
                        Category = "Music",
                        Price = 80
                    },
                    new Event
                    {
                        Title = "Theatre Night",
                        Description = "Classical drama performance",
                        Category = "Art",
                        Price = 150
                    },
                    new Event
                    {
                        Title = "E-sports Championship",
                        Description = "Major CS2 and Valorant tournament",
                        Category = "Gaming",
                        Price = 95
                    },
                    new Event
                    {
                        Title = "Hip-Hop Battle",
                        Description = "Urban dance and freestyle rap competition",
                        Category = "Dance",
                        Price = 60
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
