using System;
using System.Web.Mvc;
using OpenIdAuth.Core.Services;

namespace OpenIdAuth.UI.Controllers {
    public class RegisterController : Controller {

        private IUserService _userService;

        public RegisterController(IUserService userService) {
            _userService = userService;
        }

        public ActionResult Index() {
            return View();
        }

        //[AcceptVerbs(HttpVerbs.Post)]
        //public ActionResult Index(string username) {
        //    var isUserAvailable = _userService.IsUserAvailable(username);
        //}


        //Ajax actions for the register page
        public ActionResult CheckUser(string username) {
            var isUserAvailable = _userService.IsUserAvailable(username);
            return Json(new { UserAvailable = isUserAvailable });
        }

    }
}