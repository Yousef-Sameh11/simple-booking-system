using System.ComponentModel.DataAnnotations;

namespace Simple_booking_system.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookedQuantity {  get; set; }
        public int ResourceId { get; set; }

        public Resource Resource { get; set; } = null!;  

    }
}
