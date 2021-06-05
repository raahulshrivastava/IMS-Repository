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
    public class BrandMasterController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchBrandMaster()
        {
            try
            {
                List<BrandMaster> model = BrandMasterManager.GetAllDetail();
                return View("_SearchBrandMaster", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult AddEditBrandMaster(Int32 id = 0)
        {
            try
            {
                BrandModel model = new BrandModel();
                if (id > 0) { model = BrandMasterManager.GetDataById(id); }
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditBrandMaster(BrandModel model)
        {
            var returnValues = new object();
            try
            {
                int checkDuplicate = 0;
                checkDuplicate = BrandMasterManager.CheckDuplicateBrandName(model.BranchName, model.Id);
                if (checkDuplicate > 0) { throw new Exception("Brand Name already exist.Please enter name."); }

                if (model.Id > 0)
                {
                    BrandMasterManager.UpdateBrandMaster(model);
                    returnValues = new { Message = "Record Updated Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }
                else
                {
                    BrandMasterManager.InsertIntoBrandMaster(model);
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
                BrandMasterManager.DeleteFromBrandMaster(id);
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
