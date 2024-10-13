using AutoMapper;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Simple_booking_system.DTOs.ResourceDtos;
using Simple_booking_system.IServices.IResourceServices;
using Simple_booking_system.Models;

namespace Simple_booking_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;
        private readonly IMapper _mapper;

        public ResourceController(IResourceService resourceService, IMapper mapper)
        {

            _resourceService = resourceService;
            _mapper = mapper;
        }
        [HttpPost("AddResource")]
        public async Task<IActionResult> AddResource(ResourceRequestDto resourceRequestDto)
        {
            if (resourceRequestDto == null)
            {
                return BadRequest("Please enter the fields");
            }
            var resource = _mapper.Map<Resource>(resourceRequestDto);
            await _resourceService.AddResource(resource);
            return Ok(new { message = $"Successfully created {resourceRequestDto.Name}" });
        }

        [HttpGet("GetAllResources")]
        public async Task<IActionResult> GetAllResources()
        {
            var resources = await _resourceService.GetAllResources();
            var resourcesMapped = _mapper.Map<List<ResourceResponseDto>>(resources);
            return Ok(resourcesMapped);
        }

        [HttpGet("GetResourceById")]
        public async Task<IActionResult> GetResourceById(int resourceId)
        {
            var resource = await _resourceService.GetResourceById(resourceId);
            if (resource == null)
            {
                return NotFound();
            }
            var resourceMapped = _mapper.Map<ResourceResponseDto>(resource);
            return Ok(resourceMapped);
        }

        [HttpPut("UpdateResource")]
        public async Task<IActionResult> UpdateResource([FromBody] ResourceRequestDto resourceRequestDto)
        {
            var existingResource = await _resourceService.GetResourceByIdNoTracking(resourceRequestDto.Id);
            if (existingResource == null)
            {
                return NotFound();
            }
            if (resourceRequestDto == null)
            {
                return BadRequest("Please enter the fields");
            }
            var updatedResource = _mapper.Map<Resource>(resourceRequestDto);

            await _resourceService.UpdateResource(updatedResource);
            return Ok(new {message = $"Successfully updated resource"});
        }
    }
}
