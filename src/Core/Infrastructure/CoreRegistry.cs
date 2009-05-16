using StructureMap.Configuration.DSL;
using OpenIdAuth.Core.Model.DataAccess;
using OpenIdAuth.Core.Services;
using OpenIdAuth.Core.Model.DataAccess.Context;
using StructureMap.Attributes;

namespace OpenIdAuth.Core.Infrastructure {
    public class CoreRegistry : Registry {
        protected override void configure() {

            ForRequestedType<DB>()
                .CacheBy(InstanceScope.Hybrid);

            ForRequestedType<IImageRepository>()
                .TheDefaultIsConcreteType<SqlImageRepository>();
            ForRequestedType<IUserRepository>()
                .TheDefaultIsConcreteType<SqlUserRepository>();

            ForRequestedType<IAuthenticationService>()
                .TheDefaultIsConcreteType<AuthenticationService>();
            ForRequestedType<IImageService>()
                .TheDefaultIsConcreteType<ImageService>();
            ForRequestedType<IUserService>()
                .TheDefaultIsConcreteType<UserService>();

        }
    }
}
