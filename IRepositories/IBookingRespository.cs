using Simple_booking_system.Models;

namespace Simple_booking_system.IRepositories
{
    public interface IBookingRespository
    {
        Task<Booking> GetByIdAsync(int bookingId);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task AddAsync(Booking booking);
        Task<IEnumerable<Booking>> GetOverlappingBookingsAsync(int resourceId, DateTime dateFrom, DateTime dateTo);



    }
}
