using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using IMS.Business;
using IMS.DataContext;
using IMS.Filters;
using IMS.Models.Attributes;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IMS.Controllers
{
    [CustomAuthorizationFilter]
    public class AttributeMasterController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        public ActionResult Index()
        {
            GridModel model = new GridModel();
       
            return View(model);
        }

        public ActionResult SearchAttributeMaster(GridModel pmodel,int? page)
        {
            try
            {
                List<AttributeMaster> model = AttributeMasterManager.GetAllDataFromAttributeMaster();
                return PartialView("_SearchAttributeMaster", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult AddEditAttribute(Int64 id = 0)
        {
            try
            {
                AttributeModel master = new AttributeModel();
                if (id > 0)
                {
                    master = AttributeMasterManager.GetDataById(id);
                }
                return View(master);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult DeleteItem(Int64 id)
        {
            try
            {
                var returnValues = new object();
                AttributeMasterManager.DeleteAttributeMasterById(id);
                returnValues = new { Message = "Record deleted Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        public ActionResult AddEditAttribute(AttributeModel master)
        {
            var returnValues = new object();
            try
            {
                int checkduplicatename = 0;

                checkduplicatename = AttributeMasterManager.CheckDuplicationName(master.AttributeName, master.Id);

                if (checkduplicatename > 0)
                {
                    throw new Exception("Attribute Name Already Exist in database. Please Select another Attribute Name.");
                }
                if (master.Id > 0)
                {
                    AttributeMasterManager.EditAttributeMasterById(master);
                    returnValues = new { Message = "Record Updated Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }
                else
                {
                    AttributeMasterManager.InserIntoAttributeMaster(master);
                    returnValues = new { Message = "Record Saved Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }

            }
            catch (Exception ex)
            {
                returnValues = new { ex.Message, MessageType = (int)Utilities.Enums.Message.Error };
            }
            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }

    
        
    }
}