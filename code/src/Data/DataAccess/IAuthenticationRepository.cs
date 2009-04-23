namespace OpenIdAuth.Data.DataAccess
{
    public interface IAuthenticationRepository
    {
        bool AuthenticateUser(string userName, string password);
    }
}