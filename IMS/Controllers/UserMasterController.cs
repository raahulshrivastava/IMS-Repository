using ClosedXML.Excel;
using IMS.Business;
using IMS.DataContext;
using IMS.Filters;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IMS.Controllers
{
    [CustomAuthorizationFilter]
    public class UserMasterController : Controller
    {

        JavaScriptSerializer js = new JavaScriptSerializer();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchUserMaster()
        {
            try
            {
                List<UserModel> master = UserMasterManager.GetAllDetail();
                return PartialView("_SearchUserMaster", master);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult AddEditUserMaster(int id = 0)
        {
            try
            {

                UserModel m = new UserModel();
                m.UserTypeDdl = CommonClass.BindUserType();
                if (id > 0)
                {
                    UserMaster master = new UserMaster();
                    master = UserMasterManager.GetDataById(id);
                    m.Description = master.Description;
                    m.EmployeeName = master.EmployeeName;
                    m.Id = master.Id;
                    m.CheckIsActive = master.IsActive == "Y" ? true : false;
                    m.Password = master.Password;
                    m.UserName = master.UserName;
                    m.UserType = master.UserType;
                    m.UserTypeDdl = CommonClass.BindUserType(Convert.ToString(m.UserType));
                }
                return View(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditUserMaster(UserModel master)
        {
            var returnValues = new object();
            try
            {
                int c = 0;
                c = UserMasterManager.CheckDuplicationName(master.UserName, master.Id);
                if (c > 0) { throw new Exception("User name alreasy exist. Please enter another name."); }
                if (master.Id > 0)
                {
                    UserMasterManager.UpdateUserMaster(master);
                    returnValues = new { Message = "Record Updated Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }
                else
                {
                    UserMasterManager.InsertIntoUserMaster(master);
                    returnValues = new { Message = "Record Saved Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }

            }
            catch (Exception ex)
            {
                returnValues = new { ex.Message, MessageType = (int)Utilities.Enums.Message.Error };
            }
            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteItem(Int64 id)
        {
            try
            {
                var returnValues = new object();
                UserMasterManager.DeleteFromUserMaster(id);
                returnValues = new { Message = "Record deleted Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

   

    
    }
}