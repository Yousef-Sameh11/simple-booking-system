using Microsoft.EntityFrameworkCore;
using Simple_booking_system.Models;

namespace Simple_booking_system.Data
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }


        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Resource> Resources { get; set; }

    }
}
