using MbUnit.Framework;
using Moq;
using OpenIdAuth.Data.DataAccess;
using OpenIdAuth.Service;

namespace OpenIdAuth.UnitTests.ServiceTests {
    [TestFixture]
    public class AuthenticationServiceTests {
        private AuthenticationService _service;

        [FixtureSetUp]
        public void FixtureSetup() {
            _service = new AuthenticationService(new TestAuthenticationRepository());
        }

        [Test]
        public void AuthenticateShouldReturnFalseIfTheUserNameAndPasswordCombinationIsInvalid() {
            var result = _service.AuthenticateUser("invaliduser", "invalidpassword");
            Assert.IsFalse(result);
        }

        [Test]
        public void AuthenticateShouldReturnTrueIfTheUserNameAndPasswordCombinationIsValid() {
            var mockRepository = new Mock<IAuthenticationRepository>();
            mockRepository.Setup(x => x.AuthenticateUser("validuser", "validpwd")).Returns(true);
            var service = new AuthenticationService(mockRepository.Object);
            var result = service.AuthenticateUser("validuser", "validpwd");
            Assert.IsTrue(result);
        }
    }
}