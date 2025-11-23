using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.Models
{
    public class Ticket
    {
        [Key]
        public long TicketID { get; set; }

        [Required(ErrorMessage = "Вкажи місце")]
        [StringLength(20, ErrorMessage = "Місце не може бути довшим за 20 символів.")]
        public string Seat { get; set; } = string.Empty;

        [Required(ErrorMessage = "Вкажи ціну.")]
        [Range(0.01, 999999, ErrorMessage = "Ціна має бути більшою за нуль.")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Обери подію.")]
        public long EventID { get; set; }

        public Event Event { get; set; }
    }
}
