using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Walkistan.API.Models.Domain;
using Walkistan.API.Models.Dto.Image;
using Walkistan.API.Services;

namespace Walkistan.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto imageRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // DTO to Domain Model

            var imageDomainModel = new Image
            {
                File = imageRequest.File,
                FileExtension = Path.GetExtension(imageRequest.File.FileName),
                FileSizeInBytes = imageRequest.File.Length,
                FileName = imageRequest.FileName,
                FileDescription = imageRequest.FileDescription
            };

            await _imageService.Upload(imageDomainModel);

            return Ok(imageDomainModel);
        }


        private void FileUploadValidation(ImageUploadRequestDto imageRequest)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(Path.GetExtension(imageRequest.File.FileName)))
            {
                ModelState.AddModelError("file", "Unsoppored file extension");
            }

            if(imageRequest.File.Length > 10485760)
            {
                ModelState.AddModelError("file", "File size can not be more than 10MB");
            }
        }
    }
}
