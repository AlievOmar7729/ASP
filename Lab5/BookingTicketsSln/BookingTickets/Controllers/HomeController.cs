using Microsoft.AspNetCore.Mvc;
using BookingTickets.Models;
using BookingTickets.Models.ViewModels;
using System.Linq;

public class HomeController : Controller
{
    private readonly IBookingRepository repository;
    public int PageSize = 4;

    public HomeController(IBookingRepository repo)
    {
        repository = repo;
    }

    public IActionResult Index(string category, int page = 1)
    {
        var filteredEvents = repository.Events
            .Where(e => category == null || e.Category == category);

        var eventsPage = filteredEvents
            .OrderBy(e => e.EventID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize);

        return View(new EventsListViewModel
        {
            Events = eventsPage,
            CurrentCategory = category,

            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,

                TotalItems = filteredEvents.Count()
            }
        });
    }
}
