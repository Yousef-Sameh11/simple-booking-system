namespace Simple_booking_system.Models
{
    public class Resource
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Quantity { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
