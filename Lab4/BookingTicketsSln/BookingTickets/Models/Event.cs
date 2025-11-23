using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.Models
{
    public class Event
    {
        [Key]
        public long EventID { get; set; }

        [Required(ErrorMessage = "Подія повинна мати назву.")]
        [StringLength(100, ErrorMessage = "Назва не може бути довшою за 100 символів.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Опис теж потрібен.")]
        [StringLength(1000, ErrorMessage = "Опис занадто довгий.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Вкажіть ціну.")]
        [Range(0.01, 999999, ErrorMessage = "Ціна має бути більшою за нуль.")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Категорія є обов’язковою.")]
        [StringLength(50, ErrorMessage = "Категорія занадто довга.")]
        public string Category { get; set; } = string.Empty;

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
