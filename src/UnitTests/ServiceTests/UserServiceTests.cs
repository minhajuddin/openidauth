using MbUnit.Framework;
using System.Collections.Generic;
using OpenIdAuth.Core.Services;
using OpenIdAuth.Core.Model.Domain;
using System;

namespace OpenIdAuth.UnitTests.ServiceTests {
    [TestFixture]
    public class UserServiceTests {
        private UserService _userService;

        [FixtureSetUp]
        public void FixtureSetup() {
            _userService = new UserService(new TestUserRepository());
        }

        [Test]
        public void GetUsersShouldReturnAListOfUsers() {
            var result = _userService.GetUsers();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(typeof(IList<User>), result);
        }

        [Test]
        public void GetUsersShouldReturnMoreThanOneUser() {
            var result = _userService.GetUsers();
            Assert.IsTrue(result.Count > 0);
        }

        [Test]
        public void InsertShouldInsertDataIntoTheRepository() {
            var initialCount = _userService.GetUsers().Count;
            var user = new User("Jack", "jack");
            _userService.Insert(user);
            _userService.Save();
            var result = _userService.GetUsers().Count;

            Assert.IsTrue(++initialCount == result);
        }

        [Test]
        public void IsUserAvailableShouldReturnFalseIfUserAlreadyExists() {
            var user = new User("Jack", "jack");
            _userService.Insert(user);
            _userService.Save();
            var result = _userService.IsUserAvailable("Jack");

            Assert.IsFalse(result);
        }

        [Test]
        public void IsUserAvailableShouldReturnTrueIfUserDoesNotExist() {
            var result = _userService.IsUserAvailable("JackIsNotAvailable");

            Assert.IsTrue(result);

        }

        [Test]
        public void DeleteShouldBeAbleToDeleteUserFromDatabase() {
            var user = new User("Jack", "jack");
            _userService.Insert(user);
            _userService.Save();
            Assert.IsFalse(_userService.IsUserAvailable("Jack"));
            _userService.Delete("Jack");
            Assert.IsTrue(_userService.IsUserAvailable("Jack"));
        }

        [Test]
        public void GetUserShouldReturnAMatchingUser() {
            var result = _userService.GetUser("User1");
            Assert.IsNotNull(result);
            Assert.AreEqual("User1", result.UserName, StringComparison.OrdinalIgnoreCase);
        }
    }
}