using OpenIdAuth.Core.Model.DataAccess;

namespace OpenIdAuth.Core.Services {
    public class ImageService : IImageService {
        private readonly IImageRepository _imageRepository;

        public ImageService(IImageRepository imageRepository) {
            _imageRepository = imageRepository;
        }

        public string[] GetRandomImages() {
            return _imageRepository.GetRandomImages();
        }
    }
}