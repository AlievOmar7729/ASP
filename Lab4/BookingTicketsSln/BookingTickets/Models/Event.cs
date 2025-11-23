using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingTickets.Models
{
    public class Event
    {
        [Key]
        public long EventID { get; set; }

        [Required(ErrorMessage = "У события должно быть название.")]
        [StringLength(100, ErrorMessage = "Название не должно быть длиннее 100 символов.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Описание тоже нужно, как ни странно.")]
        [StringLength(1000, ErrorMessage = "Описание слишком длинное.")]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = "Укажи цену.")]
        [Range(0.01, 999999, ErrorMessage = "Цена должна быть больше нуля.")]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Категория обязательна.")]
        [StringLength(50, ErrorMessage = "Категория слишком длинная.")]
        public string Category { get; set; } = string.Empty;

        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
