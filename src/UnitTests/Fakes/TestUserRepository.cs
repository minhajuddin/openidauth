using System;
using System.Collections.Generic;
using System.Linq;
using OpenIdAuth.Core.Model.DataAccess;
using OpenIdAuth.Core.Model.Domain;

namespace OpenIdAuth.UnitTests {
    public class TestUserRepository : IUserRepository {

        IList<User> _users;

        public TestUserRepository() {
            _users = new List<User>();
            for (int i = 0; i < 10; i++) {
                _users.Add(new User("User" + i, "password" + i));
            }
        }

        public IList<User> GetUsers() {
            return _users;
        }

        public void Insert(User user) {
            _users.Add(user);
        }

        public void Save() {
        }

        public bool IsUserAvailable(string userName) {
            foreach (var user in _users) {
                if (user.UserName == userName) {
                    return false;
                }
            }
            return true;
        }

        public void Delete(string userName) {
            _users.Remove(_users.Single(x => x.UserName == userName));
        }

        public User GetUser(string userName) {
            return _users.
                SingleOrDefault(usr => string.Compare(userName, usr.UserName, true) == 0);
        }
    }
}