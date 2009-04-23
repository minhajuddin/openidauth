using MbUnit.Framework;
using OpenIdAuth.Data;

namespace OpenIdAuth.UnitTests {
    [TestFixture]
    public class OpenIdAuthConfigurationTests {
        [Test]
        public void GetConnectionStringReturnsTheConnectionStringStoredInTheConfigFile() {
            var expectedCS = @"Data Source=CV-002\SQLEXPRESS;Initial Catalog=OpenIdAuth;Integrated Security=True";
            var result = OpenIdAuthConfiguration.GetConnectionString();
            Assert.AreEqual(expectedCS, result);
        }

        [Test]
        public void GetNumberOfImagesReturns9() {
            var result = OpenIdAuthConfiguration.GetNumberOfImages();
            Assert.AreEqual(9, result);
        }
    }
}