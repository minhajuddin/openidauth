namespace OpenIdAuth.Core.Services {
    public interface IAuthenticationService {
        bool AuthenticateUser(string userName, string password);
    }
}