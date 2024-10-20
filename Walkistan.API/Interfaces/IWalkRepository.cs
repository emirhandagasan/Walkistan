using Walkistan.API.Helpers;
using Walkistan.API.Models.Domain;

namespace Walkistan.API.Interfaces
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(WalkQueryObject walkQueryObject);
        Task<Walk?> GetByIdAsync(int id);
        Task<Walk?> UpdateAsync(int id, Walk walk);
        Task<Walk?> DeleteAsync(int id);
    }
}
