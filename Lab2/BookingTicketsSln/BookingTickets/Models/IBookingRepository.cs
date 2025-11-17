using System.Linq;

namespace BookingTickets.Models
{
    public interface IBookingRepository
    {
        IQueryable<Event> Events { get; }
    }
}
