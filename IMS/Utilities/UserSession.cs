using System;
using System.Web;
using IMS.DataContext;
using IMS.Business;

namespace IMS.Utilities
{
    public class UserSession
    {
        public static void SetUserSession(UserModel user)
        {
            Id = user.Id;
            UserName = user.UserName;
            StoreId = user.StoreId;
            UserType = user.UserType;
            FinYear = user.FinYear;
            StoreType = user.StoreType;
            PaymentType = user.PaymentType;
        }

        public static Int64 Id
        {
            get
            {
                if (HttpContext.Current.Session["Id"] == null)
                {
                    HttpContext.Current.Session["Id"] = 0;
                }
                return Convert.ToInt32(HttpContext.Current.Session["Id"]);
            }
            set { HttpContext.Current.Session["Id"] = value; }
        }

        public static string UserName
        {
            get
            {
                if (HttpContext.Current.Session["UserName"] == null)
                {
                    HttpContext.Current.Session["UserName"] = "";
                }
                return HttpContext.Current.Session["UserName"].ToString();
            }
            set { HttpContext.Current.Session["UserName"] = value; }
        }



        public static Int32 UserType
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["UserType"]); }
            set { HttpContext.Current.Session["UserType"] = value; }
        }


        public static string FinYear
        {
            get { return Convert.ToString(HttpContext.Current.Session["FinYear"]); }
            set { HttpContext.Current.Session["FinYear"] = value; }
        }

        public static Int32 StoreId
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["StoreId"]); }
            set { HttpContext.Current.Session["StoreId"] = value; }
        }
        public static Int32 StoreType
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["StoreType"]); }
            set { HttpContext.Current.Session["StoreType"] = value; }
        }
        public static Int32 PaymentType
        {
            get { return Convert.ToInt32(HttpContext.Current.Session["PaymentType"]); }
            set { HttpContext.Current.Session["PaymentType"] = value; }
        }
    }

}
