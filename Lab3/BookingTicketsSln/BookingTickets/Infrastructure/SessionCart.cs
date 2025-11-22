using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using BookingTickets.Models;
using System.Text.Json.Serialization;

namespace BookingTickets.Infrastructure
{
    public class SessionCart : Cart
    {
        public ISession Session { get; set; }

        public static SessionCart GetCart(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()
                                  .HttpContext.Session;

            var cart = session.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(Event e, int quantity)
        {
            base.AddItem(e, quantity);
            Session.SetJson("Cart", this);
        }

        public override void RemoveItem(int eventId)
        {
            base.RemoveItem(eventId);
            Session.SetJson("Cart", this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}
