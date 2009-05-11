using MbUnit.Framework;
using Moq;
using OpenIdAuth.Core.Model.DataAccess;
using OpenIdAuth.Core.Services;
using OpenIdAuth.Core.Configuration;


namespace OpenIdAuth.UnitTests.ServiceTests {
    [TestFixture]
    public class ImageServiceTests {

        [Test]
        public void GetRandomImagesReturns9RandomImagesWhenItIsConfiguredToReturn9Images() {
            var numberOfImages = Config.GetNumberOfImages();
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