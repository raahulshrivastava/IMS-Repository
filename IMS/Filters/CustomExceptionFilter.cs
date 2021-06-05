using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.Filters
{
    public class CustomExceptionFilter : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                using (var db = new IMSContext())
                {
                    Log(filterContext.Exception);
                    //GetReturnUrl(filterContext);
                    filterContext.Result = new RedirectResult("/Web/Error");
                    filterContext.ExceptionHandled = true;
                }

            }
        }

        public string GetReturnUrl(ExceptionContext filterContext)
        {
            var returnUrl = "/Home/Index";
            if (filterContext.RouteData.Values.Count() > 0)
            {
                var url = string.Empty;
                foreach (var p in filterContext.RouteData.Values)
                {
                    url += $"/{filterContext.RouteData.Values[p.Key].ToString()}";
                }
                if (!string.IsNullOrEmpty(url))
                {
                    return url;
                }
            }
            return returnUrl;
        }
        public void Log(Exception ex)
        {
            using (var db = new IMSContext())
            {
                LogTable log = new LogTable();
                log.Helpline = ex.HelpLink;
                log.InnerException = Convert.ToString(ex.InnerException);
                log.Message = ex.Message;
                log.Source = ex.Source;
                log.StackTrace = ex.StackTrace;
                log.UserId = UserSession.Id;
                log.UserName = UserSession.Id > 0 ? UserSession.UserName : "";
                db.LogTables.Add(log);
                db.SaveChanges();
            }
        }
    }
}