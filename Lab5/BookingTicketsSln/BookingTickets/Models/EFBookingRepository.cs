using Microsoft.EntityFrameworkCore;

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
        public IQueryable<Ticket> Tickets => context.Tickets.Include(t => t.Event);

        public void CreateEvent(Event e)
        {
            context.Events.Add(e);
            context.SaveChanges();
        }

        public void UpdateEvent(Event e)
        {
            context.Events.Update(e);
            context.SaveChanges();
        }

        public void DeleteEvent(Event e)
        {
            context.Events.Remove(e);
            context.SaveChanges();
        }

        public void CreateTicket(Ticket t)
        {
            context.Tickets.Add(t);
            context.SaveChanges();
        }

        public void UpdateTicket(Ticket t)
        {
            context.Tickets.Update(t);
            context.SaveChanges();
        }

        public void DeleteTicket(Ticket t)
        {
            context.Tickets.Remove(t);
            context.SaveChanges();
        }
    }
}
