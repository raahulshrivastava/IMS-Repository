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
    public class PrefixMasterController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchPrefixMaster()
        {
            try
            {
                List<PrefixMaster> model = PrefixMasterManager.GetAllDetail();
                return View("_SearchPrefixMaster", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult AddEditPrefixMaster(Int32 id = 0)
        {
            try
            {
                PrefixMaster model = new PrefixMaster();
                if (id > 0) { model = PrefixMasterManager.GetDataById(id); }
               
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditPrefixMaster(PrefixMaster model)
        {
            var returnValues = new object();
            try
            {
                int checkdiplicate = 0;
                checkdiplicate= PrefixMasterManager.CheckDuplicationName(model.PrefixName, model.Id);
                if (checkdiplicate > 0) { throw new Exception("Prefix Name already exist.Please enter another name."); }
                if (model.Id > 0)
                {
                    PrefixMasterManager.UpdatePrefixMaster(model);
                    returnValues = new { Message = "Record Updated Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }
                else
                {
                    PrefixMasterManager.InsertIntoPrefixMaster(model);
                    returnValues = new { Message = "Record Saved Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }
            }
            catch (Exception ex)
            {
                returnValues = new { Message = ex.Message, MessageType = (int)Utilities.Enums.Message.Error };
            }
            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteItem(Int64 id)
        {
            var returnValues = new object();
            try
            {
                PrefixMasterManager.DeleteFromPrefix(id);
                returnValues = new { Message = "Record deleted Successfully.", MessageType = (int)Utilities.Enums.Message.Success };

            }
            catch (Exception ex)
            {
                returnValues = new { Message = ex.Message.ToString(), MessageType = (int)Utilities.Enums.Message.Success };
            }
            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }

 

       
    }
}