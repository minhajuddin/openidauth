using MbUnit.Framework;
using System.Web.Mvc;
using OpenIdAuth.UI.Controllers;

namespace OpenIdAuth.UnitTests.UI.Controllers {
    [TestFixture]
    public class RegisterControllerTests {
        [Test]
        public void IndexViewReturnsTheDefaultView() {
            var regController = new RegisterController();
            ViewResult result = regController.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual(string.Empty, result.ViewName);
        }

    }
}
