using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_booking_system.DTOs.BookingDtos;
using Simple_booking_system.Exceptions;
using Simple_booking_system.IServices.IBookingServices;
using System.Diagnostics.Metrics;

namespace Simple_booking_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }
        [HttpPost("BookResource")]
        public async Task<IActionResult> BookResource(BookingRequestDto bookingRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var booking = await _bookingService.BookResource(bookingRequestDto);
                return Ok(new { message = $"Succesfully booked {booking.Resource.Name} with booking ID : {booking.Id}" });
            }
            catch (ResourceNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (InvalidBookingPeriodException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (ResourceUnavailableException ex)
            {
                return Conflict(new { message = ex.Message });  
            }
        }

        [HttpGet("GetAllBookings")]
        public async Task<IActionResult> GetAllBookings()
        {
            var bookings = await _bookingService.GetAllBookings();
            var mappedBookings = _mapper.Map<List<BookingResponseDto>>(bookings);
            return Ok(mappedBookings);
        }

        [HttpGet("GetBookingById")]
        public async Task<IActionResult> GetBookingById(int bookingId)
        {
            var booking = await _bookingService.GetBookingById(bookingId);
            if (booking == null)
            {
                return NotFound();
            }

            var mappedBooking = _mapper.Map<BookingResponseDto>(booking);
            return Ok(mappedBooking);
        }
    }
}
