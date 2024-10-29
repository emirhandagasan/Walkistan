using Walkistan.API.Models.Domain;

namespace Walkistan.API.Services
{
    public interface IImageService
    {
        Task<Image> Upload(Image image);
    }
}
