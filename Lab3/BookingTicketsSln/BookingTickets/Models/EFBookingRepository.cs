namespace BookingTickets.Models
{
    public class EFBookingRepository : IBookingRepository
    {
        private BookingDbContext context;

        public EFBookingRepository(BookingDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Event> Events => context.Events;
    }
}
