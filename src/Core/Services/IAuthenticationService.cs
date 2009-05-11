namespace OpenIdAuth.Core.Services {
    public interface IAuthenticationService {
        void AuthenticateUser(string userName, string password, bool createPersistentCookie);
        bool IsValidLogin(string userName, string password);
    }
}