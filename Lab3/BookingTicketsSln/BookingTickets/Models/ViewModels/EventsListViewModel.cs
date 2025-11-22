using System.Linq;

namespace BookingTickets.Models.ViewModels
{
    public class EventsListViewModel
    {
        public IQueryable<Event> Events { get; set; }
            = Enumerable.Empty<Event>().AsQueryable();

        public PagingInfo PagingInfo { get; set; }
            = new PagingInfo();

        public string? CurrentCategory { get; set; }
    }
}
