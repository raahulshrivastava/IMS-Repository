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
    public class TaxMasterController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchTaxMaster()
        {
            try
            {
                List<TaxMaster> model = TaxMasterManager.GetAllDetail();
                return View("_SearchTaxMaster", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult AddEditTaxMaster(Int32 id = 0)
        {
            try
            {
                TaxModel model = new TaxModel();
                if (id > 0)
                {
                    TaxMaster t = new TaxMaster();
                    t = TaxMasterManager.GetDataById(id);
                    model.AppliedOn = t.AppliedOn;
                    model.CGSTValue = t.CGSTValue;
                    model.Description = t.Description;
                    model.Id = t.Id;
                    model.SGSTValue = t.SGSTValue;
                    model.TaxName = t.TaxName;
                    model.TotalValue = t.TotalValue;
                    model.CheckIsActive = t.IsActive == "Y" ? true : false;
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditTaxMaster(TaxModel model)
        {
            var returnValues = new object();
            try
            {
                int c = 0;
                c = TaxMasterManager.CheckDuplicationName(model.TaxName, model.Id);
                if (c > 0) { throw new Exception("Tax name already exist. Please select another name."); }
                if (model.Id > 0)
                {
                    TaxMasterManager.UpdateTaxMaster(model);
                    returnValues = new { Message = "Record Updated Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }
                else
                {
                    TaxMasterManager.InsertIntoTaxMaster(model);
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
                TaxMasterManager.DeleteFromTaxMaster(id);
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