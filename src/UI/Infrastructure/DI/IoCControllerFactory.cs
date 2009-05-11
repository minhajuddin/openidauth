using System.Web.Mvc;
using StructureMap;
using System;
using OpenIdAuth.UI.Controllers;

namespace OpenIdAuth.UI.Infrastructure.DI {
    public class IoCControllerFactory : DefaultControllerFactory {

        protected override IController GetControllerInstance(System.Type controllerType) {
            var controller = (IController)ObjectFactory.GetInstance(controllerType);
            return controller;
        }

        protected override System.Type GetControllerType(string controllerName) {
            if (string.Compare("Register", controllerName, true) == 0 || string.Compare("RegisterController", controllerName, true) == 0) {
                return typeof(RegisterController);
            }
            if (string.Compare("Home", controllerName, true) == 0 || string.Compare("HomeController", controllerName, true) == 0) {
                return typeof(HomeController);
            }
            throw new ArgumentException("Invalid controller name");
        }
    }
}