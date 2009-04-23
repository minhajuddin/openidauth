using OpenIdAuth.UnitTests.ServiceTests;

namespace OpenIdAuth.Service
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public string[] GetRandomImages()
        {
            return _imageRepository.GetRandomImages();
        }
    }
}