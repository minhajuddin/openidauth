using System.Linq;
using System;
using OpenIdAuth.Core.Model.DataAccess.Context;
using OpenIdAuth.Core.Configuration;

namespace OpenIdAuth.Core.Model.DataAccess {
    public class SqlAuthenticationRepository : IAuthenticationRepository {
        private DB _db;

        public SqlAuthenticationRepository() {
            _db = new DB(Config.GetConnectionString());
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