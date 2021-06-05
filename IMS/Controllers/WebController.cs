using System;
using System.Web.Mvc;
using IMS.Utilities;
using IMS.Business;
using System.Web.Script.Serialization;
using System.Linq;
using System.Web.UI.WebControls;
using IMS.DataContext;
using IMS.Filters;

namespace IMS.Controllers
{

    public class WebController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        [HttpGet]
        public ActionResult Index()
        {
            UserModel master = new UserModel();
            master.BindFinYear = CommonClass.BindFinancialPeriod();
            master.BindStore = CommonClass.BindStore();
            return View(master);
        }

        [HttpPost]
        public ActionResult Index(UserModel usermodel)
        {

            var returnValues = new object();
            try
            {
                var testdata = UserMasterManager.GetCustomer(usermodel.UserName);
                if (testdata != null)
                {
                    if (testdata.UserName == usermodel.UserName)
                    {
                        if (testdata.Password == usermodel.Password)
                        {
                            var storedata = StoreMasterManager.GetDataById(usermodel.StoreId);
                            if (storedata != null)
                            {
                                usermodel.StoreType = storedata.StoreType ?? 0;
                                usermodel.PaymentType = storedata.PaymentType ?? 0;
                            }
                            usermodel.Id = testdata.Id;
                            usermodel.UserType = testdata.UserType;
                            usermodel.IsActive = testdata.IsActive;
                            UserSession.SetUserSession(usermodel);
                            returnValues = new { Message = "User login Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            throw new Exception("Some of the credentials (i.e., email or password) does not match.");
                        }
                    }
                    else
                    {
                        throw new Exception("Some of the credentials (i.e., email or password) does not match.");
                    }

                }
                else
                {
                    throw new Exception("No match found..");
                }

            }
            catch (Exception ex)
            {
                ex.Source = "Index(Post)";
                returnValues = new { Message = ex.Message.ToString(), MessageType = (int)Utilities.Enums.Message.Error };
                return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
            }

        }
        [CustomAuthorizationFilter]
        public ActionResult IMSDashboard()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index", "Web");
        }

        public ActionResult Error(string returnUrl = "")
        {
            return View();
        }

    }
}