using Microsoft.EntityFrameworkCore;
using Walkistan.API.Data;
using Walkistan.API.Interfaces;
using Walkistan.API.Models.Domain;
using Walkistan.API.Models.Dto.Region;

namespace Walkistan.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly ApplicationDbContext _db;
        public SQLRegionRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<Region?> GetByIdAsync(int id)
        {
            return await _db.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _db.Regions.ToListAsync();
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await _db.Regions.AddAsync(region);
            await _db.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateAsync(int id, Region region)
        {
            var existingRegion = await GetByIdAsync(id);

            if(existingRegion == null)
            {
                return null;
            }

            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await _db.SaveChangesAsync();

            return existingRegion;

        }

        public async Task<Region?> DeleteAsync(int id)
        {
            var existingRegion = await GetByIdAsync(id);

            if(existingRegion == null)
            {
                return null;
            }

            _db.Regions.Remove(existingRegion);
            await _db.SaveChangesAsync();

            return existingRegion;
        }
    }
}
