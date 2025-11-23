using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.Models
{
    public class Ticket
    {
        [Key]
        public long TicketID { get; set; }

        [Required(ErrorMessage = "Вкажи место, ну же.")]
        [StringLength(20, ErrorMessage = "Место не должно быть длиннее 20 символов.")]
        public string Seat { get; set; } = string.Empty;

        [Required(ErrorMessage = "Цена обязана быть указана.")]
        [Range(0.01, 999999, ErrorMessage = "Цена должна быть больше нуля.")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Выбери событие.")]
        public long EventID { get; set; }

        public Event Event { get; set; }
    }
}
