using Microsoft.AspNetCore.Mvc;
using BookingTickets.Models;
using BookingTickets.Infrastructure;
using Microsoft.AspNetCore.Authorization;

public class CartController : Controller
{
    private readonly IBookingRepository repository;
    private readonly Cart cart;

    public CartController(IBookingRepository repo, Cart cartService)
    {
        repository = repo;
        cart = cartService;
    }

    [Authorize(Roles = "User")]
    public RedirectToActionResult AddToCart(int eventId)
    {
        var e = repository.Events.FirstOrDefault(e => e.EventID == eventId);
        if (e != null)
        {
            cart.AddItem(e, 1);
        }
        return RedirectToAction("Index");
    }

    public RedirectToActionResult Remove(int eventId)
    {
        cart.RemoveItem(eventId);
        return RedirectToAction("Index");
    }

    public IActionResult Index()
    {
        return View(cart);
    }
}
