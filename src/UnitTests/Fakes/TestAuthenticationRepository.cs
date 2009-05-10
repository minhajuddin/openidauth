using OpenIdAuth.Data.DataAccess;
using System.Collections.Generic;
using User = OpenIdAuth.Core.Model.Domain.User;
using OpenIdAuth.Core.Model.DataAccess;

namespace OpenIdAuth.UnitTests.ServiceTests {
    public class TestAuthenticationRepository : IAuthenticationRepository {

        private IList<User> _users;

        public TestAuthenticationRepository() {
            _users = new List<User>();
            for (int i = 0; i < 10; i++) {
                _users.Add(new User("User" + i, "password" + i));
            }
        }

        public bool AuthenticateUser(string userName, string password) {
            return false;
        }
    }
}