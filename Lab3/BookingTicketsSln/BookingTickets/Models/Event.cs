using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.Models
{
    public class Event
    {
        public long? EventID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        public string Category { get; set; } = string.Empty;
    }
}
