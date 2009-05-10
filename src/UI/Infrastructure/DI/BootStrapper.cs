using StructureMap;
using OpenIdAuth.Core.Infrastructure;

namespace OpenIdAuth.UI.Infrastructure.DI {
    public class BootStrapper {
        public static void ConfigureStructureMap() {
            ObjectFactory.Initialize(
                scanner => scanner.AddRegistry(new CoreRegistry()));
        }
    }
}