using Microsoft.AspNetCore.Mvc;
using BookingTickets.Models;
using BookingTickets.Infrastructure;

namespace BookingTickets.Components
{
	public class CartSummaryViewComponent : ViewComponent
	{
		private readonly Cart cart;

		public CartSummaryViewComponent(Cart cartService)
		{
			cart = cartService;
		}

		public IViewComponentResult Invoke()
		{
			int totalItems = cart.Items.Sum(i => i.Quantity);
			return View(totalItems);
		}
	}
}
