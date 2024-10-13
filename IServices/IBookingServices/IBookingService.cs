using Simple_booking_system.DTOs.BookingDtos;
using Simple_booking_system.Models;

namespace Simple_booking_system.IServices.IBookingServices
{
    public interface IBookingService
    {
         Task <IEnumerable<Booking>> GetAllBookings();
         Task<Booking> GetBookingById(int bookingId);
         Task<Booking> BookResource(BookingRequestDto bookingRequestDto);
        


    }
}
