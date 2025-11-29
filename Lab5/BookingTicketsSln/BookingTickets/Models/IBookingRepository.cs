using System.Linq;

namespace BookingTickets.Models
{
    public interface IBookingRepository
    {
        IQueryable<Event> Events { get; }
        IQueryable<Ticket> Tickets { get; }

        void CreateEvent(Event e);
        void UpdateEvent(Event e);
        void DeleteEvent(Event e);

        void CreateTicket(Ticket t);
        void UpdateTicket(Ticket t);
        void DeleteTicket(Ticket t);


    }
}
