using MbUnit.Framework;
using OpenIdAuth.Data.DataAccess;
using System.Collections.Generic;
using OpenIdAuth.Data.Domain;
using System;
using OpenIdAuth.Data.DataAccess.Context;
using OpenIdAuth.Data;

namespace OpenIdAuth.IntegrationTests.RepositoryTests {
    [TestFixture]
    public class UserRepositoryTests {
        private SqlUserRepository _repository;

        [FixtureSetUp]
        public void FixtureSetup() {
            DatabaseMaintenance.PopulateData();
            _repository = new SqlUserRepository();
        }


        [Test]
        public void GetUsersShouldReturnAnIListOfUsers() {
            var result = _repository.GetUsers();
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(typeof(IList<User>), result);
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void GetUserShouldBeAbleToGetUserWithUserName() {
            var result = _repository.GetUser("jack");
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare("jack", result.UserName, StringComparison.OrdinalIgnoreCase) == 0);
        }

        [Test]
        public void InsertUserShouldAddTheUserToTheRepository() {
            var user = new User("Phil", "sparrow");
            _repository.Insert(user);
            _repository.Save();

            var result = _repository.GetUser("phil");
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare("phil", result.UserName, StringComparison.OrdinalIgnoreCase) == 0);

        }

        [Test]
        [ExpectedArgumentException]
        public void InsertUserShouldThrowAnExceptionIfTheUserAlreadyExists() {
            var user = new User("rob", "c");
            _repository.Insert(user);
        }

        [Test]
        public void IsUserNameAvailableShouldReturnFalseIfUserAlreadyExists() {
            var result = _repository.IsUserAvailable("rob");
            Assert.IsFalse(result);
        }

        [Test]
        public void IsUserAvailableShouldReturnTrueIfUserIsNotAlreadyPresent() {
            var result = _repository.IsUserAvailable("IAmNewHere");
            Assert.IsTrue(result);
        }

        [Test]
        public void DeleteShouldDeleteTheUserFromTheDatabase() {
            _repository.Delete("scott");

            var result = _repository.GetUser("scott");
            Assert.IsNull(result);
        }
    }
}