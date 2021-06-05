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
    public class UnitMasterController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchUnitMaster()
        {
            try
            {
                List<UnitMaster> model = UnitMasterManager.GetAllDetail();
                return View("_SearchUnitMaster", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult AddEditUnitMaster(Int32 id = 0)
        {
            try
            {
                UnitModel model = new UnitModel();
                if (id > 0)
                {
                    UnitMaster master = new UnitMaster();
                    master = UnitMasterManager.GetDataById(id);
                    model.ConversionQuantity = master.ConversionQuantity;
                    model.ConversionUnit = (Int64)master.ConversionUnit;
                    model.Description = master.Description;
                    model.Id = master.Id;
                    model.UnitName = master.UnitName;
                    model.CheckIsActive = master.IsActive == "Y" ? true : false;
                }
                model.DdlConversionUnit = UnitMasterManager.BindConversionUnitDDl();
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditUnitMaster(UnitModel model)
        {
            var returnValues = new object();
            try
            {
                int c = 0;
                c = UnitMasterManager.CheckDuplicationName(model.UnitName, model.Id);
                if (c > 0) { throw new Exception("Unit name already exist. Please try another name."); }
                if (model.Id > 0)
                {
                    UnitMasterManager.UpdateUnitMaster(model);
                    returnValues = new { Message = "Record Updated Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }
                else
                {
                    UnitMasterManager.InsertIntoUnitMaster(model);
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
                UnitMasterManager.DeleteFromUnitMaster(id);
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