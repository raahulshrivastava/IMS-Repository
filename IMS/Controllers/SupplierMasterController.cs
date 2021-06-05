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
    public class SupplierMasterController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchSupplierMaster()
        {
            try
            {
                List<SupplierMaster> model = SupplierMasterManager.GetAllDetail();
                return View("_SearchSupplierMaster", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult AddEditSupplierMaster(Int32 id = 0)
        {
            try
            {
                SupplierModel m = new SupplierModel();
               
                if (id > 0)
                {
                    SupplierMaster model = new SupplierMaster();
                    model = SupplierMasterManager.GetDataById(id);
                   
                    m.Address = model.Address;
                    m.City = model.City;
                    m.ContactNumber = model.ContactNumber;
                    m.ContactPerson = model.ContactPerson;
                    m.Description = model.Description;
                    m.Email = model.Email;
                    m.GSTNumber = model.GSTNumber;
                    m.Id = model.Id;
                    m.IsActive = model.IsActive;
                    m.OpeningBalance = model.OpeningBalance;
                    m.PANNumber = model.PANNumber;
                    m.SupplierName = model.SupplierName;
                }
                return View(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditSupplierMaster(SupplierModel model)
        {
            var returnValues = new object();
            try
            {
                int countEmail, countContactNo = 0;

                countContactNo = SupplierMasterManager.CheckDuplicationContactNo(model.ContactNumber, model.Id);
                if (countContactNo > 0) { throw new Exception("Contact No. already exist. Please enter another contact no."); }

                countEmail = SupplierMasterManager.CheckDuplicationEmail(model.Email, model.Id);
                if (countEmail > 0) { throw new Exception("Email Id already exist. Please enter another Email Id"); }

                if (model.Id > 0)
                {
                    SupplierMasterManager.UpdateSupplierMaster(model);
                    returnValues = new { Message = "Record Updated Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }
                else
                {
                    SupplierMasterManager.InsertIntoSupplierMaster(model);
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
                SupplierMasterManager.DeleteFromSupplierMaster(id);
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