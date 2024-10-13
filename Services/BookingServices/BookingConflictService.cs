using Simple_booking_system.DTOs.BookingDtos;
using Simple_booking_system.Exceptions;
using Simple_booking_system.IRepositories;
using Simple_booking_system.IServices.IBookingServices;
using Simple_booking_system.Models;

namespace Simple_booking_system.Services.BookingServices
{
    public class BookingConflictService : IBookingConflictService
    {
        private readonly IBookingRespository _bookingRespository;
        private readonly IResourceRepository _resourceRepository;

        public BookingConflictService(IBookingRespository bookingRespository , IResourceRepository resourceRepository)
        {
            _bookingRespository = bookingRespository;
            _resourceRepository = resourceRepository;
        }
        public async Task CheckAvailability(int resourceId, DateTime requestedDateFrom, DateTime requestedDateTo, int requestedQuantity)
        {
            var overlappingBookings = await _bookingRespository.GetOverlappingBookingsAsync(resourceId, requestedDateFrom, requestedDateTo);
            var resource=  await _resourceRepository.GetByIdAsync(resourceId);

            if (overlappingBookings.Any(b => b.DateFrom == requestedDateFrom && b.DateTo == requestedDateTo))
            {
                throw new ResourceUnavailableException("The selected resource is already reserved for the requested time.");
            }

            int totalBookings = overlappingBookings.Sum(b => b.BookedQuantity);
            if (totalBookings + requestedQuantity > resource.Quantity)
            {
                int availableQuantity = resource.Quantity - totalBookings;
                if (availableQuantity > 0)
                {
                    throw new ResourceUnavailableException($"Cannot book {requestedQuantity} units. " +
                                            $" Only {availableQuantity} units are available for the selected period.");
                }

                else
                {
                    throw new ResourceUnavailableException("Sorry there are no available resources for this selected period");
                }


            }
        }
       
    }
}
