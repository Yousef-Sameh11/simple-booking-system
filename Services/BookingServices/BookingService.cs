using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Validations;
using Simple_booking_system.Data;
using Simple_booking_system.DTOs.BookingDtos;
using Simple_booking_system.Exceptions;
using Simple_booking_system.IRepositories;
using Simple_booking_system.IServices.IBookingServices;
using Simple_booking_system.Models;

namespace Simple_booking_system.Services.BookingServices
{
    public class BookingService : IBookingService
    {
        private readonly IResourceRepository _resourceRepository;
        private readonly IBookingRespository _bookingRespository;
        private readonly IBookingConflictService _bookingConflictService;

        public BookingService(IResourceRepository resourceRepository, IBookingRespository bookingRespository, IBookingConflictService bookingConflictService)
        {
            _resourceRepository = resourceRepository;
            _bookingRespository = bookingRespository;
            _bookingConflictService = bookingConflictService;
        }
        public async Task<Booking> BookResource(BookingRequestDto bookingRequestDto)
        {

            if (bookingRequestDto.DateFrom >= bookingRequestDto.DateTo)
            {
                throw new InvalidBookingPeriodException("DateFrom must be earlier than DateTo.");
            }

           await _bookingConflictService.CheckAvailability(
               bookingRequestDto.ResourceId,
               bookingRequestDto.DateFrom,
               bookingRequestDto.DateTo,
               bookingRequestDto.BookedQuantity);

            var newBooking = new Booking
            {
                DateFrom = bookingRequestDto.DateFrom,
                DateTo = bookingRequestDto.DateTo,
                ResourceId = bookingRequestDto.ResourceId,
                BookedQuantity = bookingRequestDto.BookedQuantity,
            };

            await _bookingRespository.AddAsync(newBooking);
            Console.WriteLine($"EMAIL SENT TO admin@admin.com FOR CREATED BOOKING WITH ID {newBooking.Id}");
            return newBooking;
        }



        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return await _bookingRespository.GetAllAsync();
        }

        public async Task<Booking> GetBookingById(int bookingId)
        {
            return await _bookingRespository.GetByIdAsync(bookingId)
;
        }


    }
}
