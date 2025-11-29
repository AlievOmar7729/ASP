using System.Collections.Generic;
using System.Linq;

namespace BookingTickets.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new();

        public virtual void AddItem(Event e, int quantity)
        {
            var item = Items.FirstOrDefault(i => i.Event.EventID == e.EventID);
            if (item == null)
            {
                Items.Add(new CartItem { Event = e, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public virtual void RemoveItem(int eventId)
        {
            Items.RemoveAll(i => i.Event.EventID == eventId);
        }

        public virtual void Clear()
        {
            Items.Clear();
        }
    }

    public class CartItem
    {
        public Event Event { get; set; }
        public int Quantity { get; set; }
    }
}
