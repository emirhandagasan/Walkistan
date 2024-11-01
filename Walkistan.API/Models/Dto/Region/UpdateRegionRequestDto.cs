﻿using System.ComponentModel.DataAnnotations;

namespace Walkistan.API.Models.Dto.Region
{
    public class UpdateRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(20, ErrorMessage = "Name can not be over 20 characters")]
        public string Name { get; set; }


        [MaxLength(1000, ErrorMessage = "Image Url can not be over 1000 characters")]
        public string? RegionImageUrl { get; set; }
    }
}
