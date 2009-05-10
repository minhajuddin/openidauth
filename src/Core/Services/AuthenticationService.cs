using OpenIdAuth.Core.Model.DataAccess;

namespace OpenIdAuth.Core.Services {
    public class AuthenticationService : IAuthenticationService {
        private readonly IAuthenticationRepository _repository;

        public AuthenticationService(IAuthenticationRepository repository) {
            _repository = repository;
        }

        public bool AuthenticateUser(string userName, string password) {
            return _repository.AuthenticateUser(userName, password);
        }
    }
}