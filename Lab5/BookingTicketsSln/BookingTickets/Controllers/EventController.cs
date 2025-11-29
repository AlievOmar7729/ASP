using Microsoft.AspNetCore.Mvc;
using BookingTickets.Models;
using Microsoft.AspNetCore.Authorization;




[Authorize]
public class EventController : Controller
{
    private IBookingRepository repo;

    public EventController(IBookingRepository repository)
    {
        repo = repository;
    }

    public IActionResult Index() => View(repo.Events);

    public IActionResult Details(long id)
    {
        var ev = repo.Events.FirstOrDefault(e => e.EventID == id);
        return ev == null ? NotFound() : View(ev);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(Event ev)
    {
        if (ModelState.IsValid)
        {
            repo.CreateEvent(ev);
            return RedirectToAction("Index");
        }
        return View(ev);
    }

    public IActionResult Edit(long id)
    {
        var ev = repo.Events.FirstOrDefault(e => e.EventID == id);
        return ev == null ? NotFound() : View(ev);
    }

    [HttpPost]
    public IActionResult Edit(Event ev)
    {
        if (ModelState.IsValid)
        {
            repo.UpdateEvent(ev);
            return RedirectToAction("Index");
        }
        return View(ev);
    }

    public IActionResult Delete(long id)
    {
        var ev = repo.Events.FirstOrDefault(e => e.EventID == id);
        return ev == null ? NotFound() : View(ev);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(long EventID)
    {
        var ev = repo.Events.FirstOrDefault(e => e.EventID == EventID);
        if (ev != null)
        {
            repo.DeleteEvent(ev);
        }
        return RedirectToAction("Index");
    }
}
