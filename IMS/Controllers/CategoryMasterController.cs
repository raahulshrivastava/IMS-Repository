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
    public class CategoryMasterController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchCategoryMaster()
        {
            try
            {
                List<CategoryMaster> model = CategoryMasterManager.GetAllDetail();
                return View("_SearchCategoryMaster", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult AddEditCategoryMaster(Int32 id = 0)
        {
            try
            {
                
                CategoryModel m = new CategoryModel();
                if (id > 0)
                {
                    CategoryMaster model = new CategoryMaster();
                    model = CategoryMasterManager.GetDataById(id);
                    m.CategoryName = model.CategoryName;
                    m.Description = model.Description;
                    m.Id = model.Id;
                    m.IsActive = model.IsActive;
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
        public ActionResult AddEditCategoryMaster(CategoryModel model)
        {
            var returnValues = new object();
            try
            {
                int checkDuplicate = 0;
                checkDuplicate = CategoryMasterManager.CheckDuplicationName(model.CategoryName, model.Id);
                if (checkDuplicate > 0) { throw new Exception("Category Name already exist. Please enter another name."); }
                if (model.Id > 0)
                {
                    CategoryMasterManager.UpdateCategoryMaster(model);
                    returnValues = new { Message = "Record Updated Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
                }
                else
                {
                    CategoryMasterManager.InsertIntoCategoryMaster(model);
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
                CategoryMasterManager.DeleteFromCategoryMaster(id);
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