//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Http.Controllers;
//using System.Web.Http.Filters;

//namespace CustomOAuthAPI.OAuth.Attributes
//{
//    public class YourActionFilterAttribute : ActionFilterAttribute
//    {
//        public override void OnActionExecuting(ActionExecutingContext filterContext)
//        {
//            base.OnActionExecuting(filterContext);

//            var context = filterContext.HttpContext;

//            if (context.User.Identity.AuthenticationType == "Forms" && context.User.Identity.IsAuthenticated)
//            {
//                var identity = (FormsIdentity)context.User.Identity;
//                var userData = identity.Ticket.UserData;
//                var serializer = new JavaScriptSerializer();
//                var userInfo = serializer.Deserialize<UserInfo>(userData);
//                var lastLoginToken = UserHelper.LastLoginToken();

//                if (userInfo.LoginToken != lastLoginToken)
//                {
//                    //throw new Exception("We noticed a login to your account from other place.");
//                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "LogInFromOtherPlace", controller = "Home" }));
//                }

//                if (UserHelper.IsForceChangePassword)
//                {
//                    string actionName = filterContext.ActionDescriptor.ActionName;
//                    string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

//                    if (controllerName != "Home" && actionName != "ForceChangePassword")
//                    {
//                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "ForceChangePassword", controller = "Home" }));
//                    }
//                }

//            }
//        }
//    }
//}