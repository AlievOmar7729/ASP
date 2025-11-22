using Microsoft.EntityFrameworkCore;

namespace BookingTickets.Models
{
    public class BookingDbContext : DbContext
    {
        public BookingDbContext(DbContextOptions<BookingDbContext> options)
            : base(options) { }

        public DbSet<Event> Events => Set<Event>();
    }
}
