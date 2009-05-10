using MbUnit.Framework;
using OpenIdAuth.UI.Infrastructure.DI;
using StructureMap;
using System.Web.Mvc;
using System.Web.Routing;
using UnitTests;
using OpenIdAuth.UI.Controllers;

namespace OpenIdAuth.UnitTests.IoCConfigTests {
    [TestFixture]
    public class UiConfigTests {

        private IControllerFactory _iocFactory;

        [FixtureSetUp]
        public void FixtureSetup() {
            BootStrapper.ConfigureStructureMap();
            _iocFactory = new IoCControllerFactory();
        }

        [Test]
        public void CanGetARegisterController() {
            var result = ObjectFactory.GetInstance<RegisterController>();
            Assert.IsNotNull(result);
        }

        [Test]
        public void CanGetARegisterControllerFromIoCControllerFactory() {
            var mockRequestContext = new RequestContext(MvcMockHelpers.FakeHttpContext(), new RouteData());
            var result = _iocFactory.CreateController(mockRequestContext, "Register");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(typeof(RegisterController), result);
        }

        [Test]
        public void CanGetAHomeControllerFromIoCControllerFactory() {
            var mockRequestContext = new RequestContext(MvcMockHelpers.FakeHttpContext(), new RouteData());
            var result = _iocFactory.CreateController(mockRequestContext, "home");
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(typeof(HomeController), result);
        }

    }
}
