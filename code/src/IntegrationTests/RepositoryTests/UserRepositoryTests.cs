using MbUnit.Framework;
using OpenIdAuth.Data.DataAccess;
using System.Collections.Generic;
using OpenIdAuth.Data.Domain;
using System;

namespace OpenIdAuth.IntegrationTests.RepositoryTests {
    [TestFixture]
    public class UserRepositoryTests {
        private SqlUserRepository _repository;

        [FixtureSetUp]
        public void FixtureSetup() {
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
            var result = _repository.GetUser("jackMan");
            Assert.IsNotNull(result);
            Assert.IsTrue(string.Compare("jackMan", result.UserName, StringComparison.OrdinalIgnoreCase) == 0);
        }

        //[Test]
        //public void InsertUserShouldAddTheUserToTheRepository() {
        //    var user = new User("jack", "sparrow");
        //    _repository.Insert(user);
        //    _repository.Save();


        //}

        //[Test]
        //public void IsUserNameAvailableShouldReturnFalseIfUserAlreadyExists()
        //{
        //    var userRepository = new UserRepository();
        //    var user = new User {UserName = "test"};
        //    userRepository.Insert(user);

        //    var result = userRepository.IsUsernameAvailable("test");
        //    Assert.IsTrue(result);
        //}
    }
}