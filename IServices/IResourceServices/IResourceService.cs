using Simple_booking_system.DTOs.ResourceDtos;
using Simple_booking_system.Models;
using System.Threading.Tasks;

namespace Simple_booking_system.IServices.IResourceServices
{
    public interface IResourceService
    {
        Task<IEnumerable<Resource>> GetAllResources();
        Task<Resource> GetResourceById(int resourceId);
        Task AddResource(Resource resource);
        Task UpdateResource(Resource resource);
        Task<Resource> GetResourceByIdNoTracking(int resourceId);

    }
}
