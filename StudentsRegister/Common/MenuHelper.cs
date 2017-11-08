using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsRegister.Common
{
    public static class MenuHelper
    {
        public static string IsActive(this HtmlHelper html, string controller, string action, string className = "active")
        {
            //get the current URL from route
            var routeData = html.ViewContext.RouteData;

            //get the current controller
            var routeController = (string) routeData.Values["controller"];

            //get the current action
            var routeAction = (string)routeData.Values["action"];

            //comparison values
            bool isActiveController = controller == routeController;
            bool isActiveAction = action == routeAction;

            return isActiveController && isActiveAction ? className : string.Empty;
        }
    }
}