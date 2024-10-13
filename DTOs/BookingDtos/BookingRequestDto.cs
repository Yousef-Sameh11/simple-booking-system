using Simple_booking_system.DTOs.ResourceDtos;
using System.ComponentModel.DataAnnotations;

namespace Simple_booking_system.DTOs.BookingDtos
{
    public class BookingRequestDto
    {
        public int Id { get; set; }
        [Required]
        public DateTime DateFrom { get; set; }
        [Required]
        public DateTime DateTo { get; set; }
        
        public int BookedQuantity { get; set; }
        [Required]
        public int ResourceId { get; set; }
    }
}
