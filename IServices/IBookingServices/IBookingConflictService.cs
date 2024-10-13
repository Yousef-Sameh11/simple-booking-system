namespace Simple_booking_system.IServices.IBookingServices
{
    public interface IBookingConflictService
    { 
        Task CheckAvailability(int resourceId, DateTime requestedDateFrom, DateTime requestedDateTo, int requestedQuantity);
    }
}
