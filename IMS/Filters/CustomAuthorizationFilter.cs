using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.Filters
{
    public class CustomAuthorizationFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (UserSession.Id == 0)
            {
                filterContext.Result = new RedirectResult("/Web/Index");
            }
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {

        }
    }
}