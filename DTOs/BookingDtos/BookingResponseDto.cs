namespace Simple_booking_system.DTOs.BookingDtos
{
    public class BookingResponseDto
    {
        public int Id { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int BookedQuantity { get; set; }
        public int ResourceId { get; set; }
        public string ResourceName { get; set; } = null!;
    }
}
