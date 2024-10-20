using Walkistan.API.Models.Domain;

namespace Walkistan.API.Helpers
{
    public class WalkQueryObject
    {
        public string? Name { get; set; } = null;
        public string? RegionName { get; set; } = null;
        public string? DifficultyName { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool IsDecsending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
