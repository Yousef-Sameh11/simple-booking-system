using Simple_booking_system.Models;

namespace Simple_booking_system.IRepositories
{
    public interface IResourceRepository
    {
        Task<Resource> GetByIdAsync(int resourceId);
        Task<Resource> GetByIdAsNoTracking(int resourceId);
        Task<IEnumerable<Resource>> GetAllAsync();
        Task AddAsync(Resource resource);
        Task Update(Resource resource);
    }
}
