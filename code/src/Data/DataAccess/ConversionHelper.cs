using OpenIdAuth.Data.Domain;

namespace OpenIdAuth.Data.DataAccess {
    public static class ConversionHelper {
        public static User ConvertToDomainUser(Entity.User user) {
            return new User(user.UserName, user.Password) { UserID = user.UserId };
        }

        public static Entity.User ConvertToEntityUser(User user) {
            return new Entity.User { UserId = user.UserID, UserName = user.UserName, Password = user.Password };
        }
    }
}