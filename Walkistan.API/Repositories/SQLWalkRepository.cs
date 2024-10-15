using Microsoft.EntityFrameworkCore;
using Walkistan.API.Data;
using Walkistan.API.Interfaces;
using Walkistan.API.Models.Domain;

namespace Walkistan.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly ApplicationDbContext _db;
        public SQLWalkRepository(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<Walk> CreateAsync(Walk walk)
        {
            await _db.Walks.AddAsync(walk);
            await _db.SaveChangesAsync();
            return walk;
        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _db.Walks.Include("Region").Include("Difficulty").ToListAsync();
        }

        public async Task<Walk?> GetByIdAsync(int id)
        {
            return await _db.Walks
                .Include(x => x.Region)
                .Include(x => x.Difficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(int id, Walk walk)
        {
            var existingWalk = await GetByIdAsync(id);

            if(existingWalk == null)
            {
                return null;
            }

            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId = walk.RegionId;

            await _db.SaveChangesAsync();

            return existingWalk;
        }

        public async Task<Walk?> DeleteAsync(int id)
        {
            var existingWalk = await GetByIdAsync(id);
            
            if(existingWalk == null)
            {
                return null;
            }

            _db.Walks.Remove(existingWalk);
            await _db.SaveChangesAsync();

            return existingWalk;
        }

    }
}
