using System.ComponentModel.DataAnnotations;

namespace Walkistan.API.Models.Dto.Walk
{
    public class AddWalkRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters")]
        [MaxLength(50, ErrorMessage = "Name can not be over 50 characters")]
        public string Name { get; set; }


        [Required]
        [MinLength(5, ErrorMessage = "Name must be at least 5 characters")]
        [MaxLength(1000, ErrorMessage = "Name can not be over 1000 characters")]
        public string Description { get; set; }


        [Required]
        [Range(3, 50, ErrorMessage = "Length must be between 3 and 50")]
        public double LengthInKm { get; set; }


        [MaxLength(1000, ErrorMessage = "Name can not be over 1000 characters")]
        public string? WalkImageUrl { get; set; }


        [Required]
        [Range(1, 3, ErrorMessage = "Difficulty Id must be between 1 and 3")]
        public int DifficultyId { get; set; }


        [Required]
        public int RegionId { get; set; }
    }
}
