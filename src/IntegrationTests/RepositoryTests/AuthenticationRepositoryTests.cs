using MbUnit.Framework;
using OpenIdAuth.Core.Model.DataAccess;

namespace OpenIdAuth.IntegrationTests.RepositoryTests {
    [TestFixture]
    public class AuthenticationRepositoryTests {
        private SqlAuthenticationRepository _repository;

        [FixtureSetUp]
        public void FixtureSetup() {
            DatabaseMaintenance.PopulateData();
            _repository = new SqlAuthenticationRepository();
        }

        [Test]
        public void AuthenticateUserShouldReturnFalseIfUserNamePasswordCombinationIsInvalid() {
            var result = _repository.AuthenticateUser("jack", "Jaxe");
            Assert.IsFalse(result);
        }

        [Test]
        public void AuthenticateUserShouldReturnTrueIfUserNamePasswordCombinationIsValid() {
            var result = _repository.AuthenticateUser("jack", "jake");
            Assert.IsTrue(result);
        }

    }
}