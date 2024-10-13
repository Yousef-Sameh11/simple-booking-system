using AutoMapper;
using Simple_booking_system.DTOs.ResourceDtos;
using Simple_booking_system.Models;

namespace Simple_booking_system.Helpers
{
    public class ResourceMappingProfiles : Profile
    {
        public ResourceMappingProfiles()
        {
            CreateMap<ResourceRequestDto, Resource>().ReverseMap();

            CreateMap<ResourceResponseDto, Resource>().ReverseMap();
        }
    }
}
