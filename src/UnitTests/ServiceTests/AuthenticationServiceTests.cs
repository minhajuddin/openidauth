using MbUnit.Framework;
using Moq;
using OpenIdAuth.Core.Services;
using OpenIdAuth.Core.Model.Domain;
using OpenIdAuth.Core.Model.DataAccess;

namespace OpenIdAuth.UnitTests.ServiceTests {
    [TestFixture]
    public class AuthenticationServiceTests {
        [Test]
        public void IsValidLoginShouldReturnFalseIfTheUserNameAndPasswordCombinationIsInvalid() {
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(us => us.GetUser("invaliduser")).Returns(new User("invaliduser", "somepwd"));
            var service = new AuthenticationService(mockUserService.Object);
            var result = service.IsValidLogin("invaliduser", "invalidpassword");
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidLoginShouldReturnTrueIfUsernamePwdComboIsInvalid() {
            var mockUserService = new Mock<IUserService>();
            mockUserService.Setup(us => us.GetUser("test")).Returns(new User("test", "pwd"));
            var service = new AuthenticationService(mockUserService.Object);
            var result = service.IsValidLogin("test", "pwd");
            Assert.IsTrue(result);
        }


        //TODO: Find a way to test the setting of the auth cookie

        //[Test]
        //public void AuthenticateShouldSetAuthCookieIfUsernamePwdComboIsValid() {
        //    var mockUserService = new Mock<IUserService>();
        //    mockUserService.Setup(us => us.GetUser("test")).Returns(new User("test", "pwd"));
        //    var service = new AuthenticationService(mockUserService.Object);

        //    Assert.IsTrue(result);
        //}


        //[Test]
        //public void AuthenticateSouldReturnTrueIfTheUserNameAndPasswordCombinationIsValid() {
        //    var mockRepository = new Mock<IAuthenticationRepository>();
        //    mockRepository.Setup(x => x.AuthenticateUser("validuser", "validpwd")).Returns(true);
        //    var service = new AuthenticationService(mockRepository.Object);
        //    var result = service.AuthenticateUser("validuser", "validpwd");
        //    Assert.IsTrue(result);
        //}
    }
}