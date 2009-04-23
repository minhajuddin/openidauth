using MbUnit.Framework;
using OpenIdAuth.Data;
using Moq;
using OpenIdAuth.Service;

namespace OpenIdAuth.UnitTests.ServiceTests {
    [TestFixture]
    public class ImageServiceTests {

        [Test]
        public void GetRandomImagesReturns9RandomImagesWhenItIsConfiguredToReturn9Images() {
            var numberOfImages = OpenIdAuthConfiguration.GetNumberOfImages();
            var mockRepository = new Mock<IImageRepository>();
            mockRepository.Setup(x => x.GetRandomImages()).Returns(new[]
                                                                       {
                                                                           "first", "second", "third", "first", "second",
                                                                           "third", "first", "second", "third"
                                                                       });
            var service = new ImageService(mockRepository.Object);
            var result = service.GetRandomImages();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(typeof(string[]), result);
            Assert.IsTrue(result.Length == numberOfImages);
        }
    }
}