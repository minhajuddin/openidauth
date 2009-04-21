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
        public void CanCreateUserWithAUserNameProperty() {
            var user = new User("Jack");
            Assert.IsNotNull(user);
            Assert.AreEqual("Jack", user.UserName);
        }
    }
}