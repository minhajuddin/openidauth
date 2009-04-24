using System.Linq;
using OpenIdAuth.Data.DataAccess.Context;
using System;

namespace OpenIdAuth.Data.DataAccess {
    public class SqlAuthenticationRepository : IAuthenticationRepository {
        private DBDataContext _db;

        public SqlAuthenticationRepository() {
            _db = new DBDataContext(OpenIdAuthConfiguration.GetConnectionString());
        }

        public bool AuthenticateUser(string userName, string password) {
            var result =
                _db.Users.
                    Where(x => x.UserName == userName && x.Password == password)
                    .Count();
            return result == 1;
        }
    }
}