using Microsoft.EntityFrameworkCore;
using Simple_booking_system.Data;
using Simple_booking_system.IRepositories;
using Simple_booking_system.Models;

namespace Simple_booking_system.Repositories
{
    public class BookingRespository : IBookingRespository
    {
        private readonly DataContext _context;

        public BookingRespository(DataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Booking booking)
        {
            _context.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Booking>> GetAllAsync()
        {
           return await _context.Bookings.Include(r=>r.Resource).ToListAsync();
        }

        public async Task<Booking> GetByIdAsync(int bookingId)
        { var booking = await _context.Bookings
                                  .Include(b => b.Resource)
                                  .FirstOrDefaultAsync(b => b.Id == bookingId);
            return booking!;
        }

        public async Task<IEnumerable<Booking>> GetOverlappingBookingsAsync(int resourceId, DateTime requestedDateFrom, DateTime requestedDateTo)
        {
          return await _context.Bookings
                        .Where(b => b.ResourceId ==resourceId &&
                           b.DateFrom < requestedDateTo &&
                           b.DateTo > requestedDateFrom)
                            .ToListAsync();
        }
    }
}
