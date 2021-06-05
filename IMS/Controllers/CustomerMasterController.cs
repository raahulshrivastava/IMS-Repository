﻿using ClosedXML.Excel;
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
    public class CustomerMasterController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchCustomerMaster()
        {
            try
            {
                List<CustomerMaster> model = CustomerMasterManager.GetAllDetail();
                return View("_SearchCustomerMaster", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult AddEditCustomerMaster(Int32 id = 0)
        {
            try
            {
                CustomerModel m = new CustomerModel();
                
                if (id > 0)
                {
                    CustomerMaster model = new CustomerMaster();
                    model = CustomerMasterManager.GetDataById(id);
                    m.Address = model.Address;
                    m.ContactNumber = model.ContactNumber;
                    m.CustomerName = model.CustomerName;
                    m.Description = model.Description;
                    m.EmailId = model.EmailId;
                    m.Id = model.Id;
                    m.IsActive = model.IsActive;
                    m.OpeningBalance = model.OpeningBalance;
                    m.PanNumber = model.PanNumber;
                    m.CheckIsActive = model.IsActive == "Y" ? true : false;
                }
                return View(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditCustomerMaster(CustomerModel model)
        {
            var returnValues = new object();
            try
            {
                int countEmail, countContactNo = 0;

                countContactNo = CustomerMasterManager.CheckDuplicationContactNo(model.ContactNumber, model.Id);
                if (countContactNo > 0) { throw new Exception("Contact No. already exist. Please enter another contact no."); }

                countEmail = CustomerMasterManager.CheckDuplicationEmail(model.EmailId, model.Id);
                if (countEmail > 0) { throw new Exception("Email Id already exist. Please enter another Email Id"); }

                if (model.Id > 0)
                {
                    CustomerMasterManager.UpdateCustomerMaster(model);
                    returnValues = new { Message = "Record Updated Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }
                else
                {
                    CustomerMasterManager.InsertIntoCustomerMaster(model);
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
                CustomerMasterManager.DeleteFromCustomerMaster(id);
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