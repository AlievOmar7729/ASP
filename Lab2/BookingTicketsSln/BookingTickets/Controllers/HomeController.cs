using Microsoft.AspNetCore.Mvc;
using BookingTickets.Models;
using BookingTickets.Models.ViewModels;


public class HomeController : Controller
{
    private IBookingRepository repository;
    public int PageSize = 4; 
    public HomeController(IBookingRepository repo)
    {
        repository = repo;
    }

    public IActionResult Index(int page = 1)
    {
        var eventsQuery = repository.Events
            .OrderBy(e => e.EventID)
            .Skip((page - 1) * PageSize)
            .Take(PageSize);

        var viewModel = new EventsListViewModel
        {
            Events = eventsQuery,
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = repository.Events.Count()
            }
        };

        return View(viewModel);
    }
}
