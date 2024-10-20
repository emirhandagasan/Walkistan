using Walkistan.API.Models.Dto.Difficulty;
using Walkistan.API.Models.Dto.Region;

namespace Walkistan.API.Models.Dto.Walk
{
    public class WalkDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }


        public RegionDto Region { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }
}
