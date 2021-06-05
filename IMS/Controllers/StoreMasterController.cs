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
    public class StoreMasterController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchStoreMaster()
        {
            try
            {
                List<StoreMaster> model = StoreMasterManager.GetAllDetail();
                return PartialView("_SearchStoreMaster", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult AddEditStoreMaster(Int32 id = 0)
        {
            try
            {
                StoreMaster master = new StoreMaster();

                if (id > 0)
                {
                    master = StoreMasterManager.GetDataById(id);
                }
                return View(master);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditStoreMaster(StoreMaster master)
        {

            var returnValues = new object();
            try
            {
                int checkduplicate =0;
                checkduplicate= StoreMasterManager.CheckDuplicationName(master.OwnerName, master.Id);
                if (checkduplicate>0) { throw new Exception("Owner name already exist. Please enter another name."); }
                if (master.Id > 0)
                {
                    StoreMasterManager.UpdateStoreMaster(master);
                    returnValues = new { Message = "Record Updated Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }
                else
                {
                    StoreMasterManager.InsertIntoStoreMaster(master);
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
                StoreMasterManager.DeleteFromStoreMaster(id);
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