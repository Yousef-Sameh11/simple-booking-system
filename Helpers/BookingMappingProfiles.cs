using AutoMapper;
using Simple_booking_system.DTOs.BookingDtos;
using Simple_booking_system.Models;

namespace Simple_booking_system.Helpers
{
    public class BookingMappingProfiles : Profile
    {
        public BookingMappingProfiles()
        {
            CreateMap<BookingRequestDto, Booking>().ReverseMap();
            CreateMap<Booking, BookingResponseDto>()
            .ForMember(opt=>opt.ResourceName,dest=>dest.MapFrom(src=>src.Resource.Name));
        }
    }
}
