using Microsoft.EntityFrameworkCore;
using Simple_booking_system.Data;
using Simple_booking_system.DTOs.ResourceDtos;
using Simple_booking_system.IRepositories;
using Simple_booking_system.IServices.IResourceServices;
using Simple_booking_system.Models;
using System.ComponentModel.Design;

namespace Simple_booking_system.Services.ResourceServices
{
    public class ResourceService : IServices.IResourceServices.IResourceService
    {
        private readonly IResourceRepository _resourceRepository;

        public ResourceService(IResourceRepository resourceRepository)
        {
            _resourceRepository = resourceRepository;
        }

        public async Task AddResource(Resource resource)
        {
            await _resourceRepository.AddAsync(resource);
        }



        public async Task<IEnumerable<Resource>> GetAllResources()
        {

            return await _resourceRepository.GetAllAsync();
        }

        public async Task<Resource> GetResourceById(int resourceId)
        {
            return await _resourceRepository.GetByIdAsync(resourceId);

        }
        public async Task<Resource> GetResourceByIdNoTracking(int resourceId)
        {
            return await _resourceRepository.GetByIdAsNoTracking(resourceId);

        }
        public async Task UpdateResource(Resource resource)
        {
            await _resourceRepository.Update(resource);
        }
    }
}
