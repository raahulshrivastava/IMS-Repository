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
    public class AttributeDetailMasterController : Controller
    {

        JavaScriptSerializer js = new JavaScriptSerializer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchAttributeDetailMaster()
        {
            List<AttributeModel> model = AttributeMasterManager.GetAllDetail();
            return PartialView("_SearchAttributeDetailMaster", model);
        }

        [HttpGet]
        public ActionResult AddEditAttributeDetailMaster(int id = 0)
        {
            try
            {
                AttributeModel M = new AttributeModel();
                M.DdlAttribute = AttributeMasterManager.BindAttributeDropDown();
                if (id > 0)
                {
                    M = AttributeMasterManager.GetAttrDetailMasterDataById(id);
                    M.DdlAttribute = AttributeMasterManager.BindAttributeDropDown(M.AttributeName);
                }


                return View(M);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditAttributeDetailMaster(AttributeModel model)
        {
            var returnValues = new object();
            try
            {

                int CheckDuplicateDetailName = 0;

                CheckDuplicateDetailName = AttributeMasterManager.CountDuplicateAttributeName(model.DetailName, model.Id);

                if (CheckDuplicateDetailName > 0)
                {
                    throw new Exception("Attribute Code with the same name already exist. Please try another one.");
                }

                if (model.Id > 0)
                {
                    AttributeMasterManager.UpdateAttributeDetailMaster(model);
                    returnValues = new { Message = "Record Updated Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }
                else
                {
                    AttributeMasterManager.InsertIntoAttributeDetailMaster(model);
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
            string message = "";
            int messageType = (int)Utilities.Enums.Message.Success;
            AttributeMasterManager.DeleteFromAttributeDetailMaster(id, out message, out messageType);
            returnValues = new { Message = message, MessageType = (int)Utilities.Enums.Message.Success };
            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }


    }
}