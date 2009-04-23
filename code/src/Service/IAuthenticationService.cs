namespace OpenIdAuth.Service
{
    public interface IAuthenticationService
    {
        bool AuthenticateUser(string userName, string password);
    }
}