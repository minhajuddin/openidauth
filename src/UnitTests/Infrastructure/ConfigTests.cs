using MbUnit.Framework;
using OpenIdAuth.Core.Configuration;

namespace OpenIdAuth.Infrastructure.UnitTests {
    [TestFixture]
    public class ConfigTests {
        [Test]
        public void GetConnectionStringReturnsTheConnectionStringStoredInTheConfigFile() {
            var expectedCS = @"Data Source=CV-002\SQLEXPRESS;Initial Catalog=OpenIdAuth;Integrated Security=True";
            var result = Config.GetConnectionString();
            Assert.AreEqual(expectedCS, result);
        }

        [Test]
        public void GetNumberOfImagesReturns9() {
            var result = Config.GetNumberOfImages();
            Assert.AreEqual(9, result);
        }
    }
}