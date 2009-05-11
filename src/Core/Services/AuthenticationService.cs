using OpenIdAuth.Core.Model.DataAccess;
using System.Web.Security;

namespace OpenIdAuth.Core.Services {
    public class AuthenticationService : IAuthenticationService {
        private readonly IUserService _userService;

        public AuthenticationService(IUserService userService) {
            _userService = userService;
        }

        public void AuthenticateUser(string userName, string password, bool createPersistentCookie) {
            if (IsValidLogin(userName, password)) {
                //Set the auth cookie
                FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
            }
        }

        public bool IsValidLogin(string userName, string password) {
            var user = _userService.GetUser(userName);
            return user.Password == password;
        }
    }
}