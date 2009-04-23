using MbUnit.Framework;
using OpenIdAuth.Data.Domain;

namespace OpenIdAuth.UnitTests {
    /*
     * User:
     *      Should have a readonly Username property
     *      Should have accept UserName through the constructor
     */
    [TestFixture]
    public class UserTests {
        [Test]
        public void CanCreateUserWithAUserNameAndPasswordProperty() {
            var user = new User("Jack", "password");
            Assert.IsNotNull(user, "password");
            Assert.AreEqual("Jack", user.UserName);
        }
    }
}