using Microsoft.AspNetCore.Mvc;
using BookingTickets.Models;
using Microsoft.EntityFrameworkCore;

public class TicketController : Controller
{
	private IBookingRepository repo;

	public TicketController(IBookingRepository repository)
	{
		repo = repository;
	}

	public IActionResult Index()
	{
		return View(repo.Tickets.Include(t => t.Event));
	}

	public IActionResult Details(long id)
	{
		var t = repo.Tickets.FirstOrDefault(t => t.TicketID == id);
		return t == null ? NotFound() : View(t);
	}

	public IActionResult Create()
	{
		ViewBag.Events = repo.Events.ToList();
		return View();
	}

	[HttpPost]
	public IActionResult Create(Ticket t)
	{
		if (ModelState.IsValid)
		{
			repo.CreateTicket(t);
			return RedirectToAction("Index");
		}

		ViewBag.Events = repo.Events.ToList();
		return View(t);
	}

	public IActionResult Edit(long id)
	{
		var t = repo.Tickets.FirstOrDefault(x => x.TicketID == id);
		if (t == null) return NotFound();

		ViewBag.Events = repo.Events.ToList();
		return View(t);
	}

	[HttpPost]
	public IActionResult Edit(Ticket t)
	{
		if (ModelState.IsValid)
		{
			repo.UpdateTicket(t);
			return RedirectToAction("Index");
		}

		ViewBag.Events = repo.Events.ToList();
		return View(t);
	}

	public IActionResult Delete(long id)
	{
		var t = repo.Tickets.FirstOrDefault(x => x.TicketID == id);
		return t == null ? NotFound() : View(t);
	}

	[HttpPost]
	public IActionResult DeleteConfirmed(long id)
	{
		var t = repo.Tickets.FirstOrDefault(x => x.TicketID == id);
		if (t != null) repo.DeleteTicket(t);

		return RedirectToAction("Index");
	}
}
