using Microsoft.EntityFrameworkCore;
using Simple_booking_system.Data;
using Simple_booking_system.IRepositories;
using Simple_booking_system.Models;

namespace Simple_booking_system.Repositories
{
    public class ResourceRepository : IResourceRepository
    {
        private readonly DataContext _context;

        public ResourceRepository(DataContext context)
        {
           _context = context;
        }
        public async Task AddAsync(Resource resource)
        {
            await _context.AddAsync(resource);
            await _context.SaveChangesAsync();  
        }

        public async Task<IEnumerable<Resource>> GetAllAsync()
        {
            return await _context.Resources.ToListAsync();
        }

        public async Task<Resource> GetByIdAsNoTracking(int resourceId)
        { var resource = await _context.Resources.AsNoTracking().FirstOrDefaultAsync(i => i.Id == resourceId);
            return resource!;
        }

        public async Task<Resource> GetByIdAsync(int resourceId)
        {var resource = await _context.Resources.FirstOrDefaultAsync(i => i.Id == resourceId);
            return resource!;
        }

        public async Task Update(Resource resource)
        {
            _context.Resources.Update(resource);
            await _context.SaveChangesAsync();
        }
    }
}
