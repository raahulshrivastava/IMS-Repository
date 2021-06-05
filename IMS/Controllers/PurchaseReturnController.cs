using System;
using System.Web.Mvc;
using IMS.Business;
using System.Web.Script.Serialization;
using IMS.Utilities;
using System.IO;
using ClosedXML.Excel;
using System.Linq;
using IMS.Filters;
using IMS.Models.PurchaseReturn;

namespace IMS.Controllers
{
    [CustomAuthorizationFilter]
    public class PurchaseReturnController : Controller
    {


        JavaScriptSerializer js = new JavaScriptSerializer();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            try
            {
                return PartialView("_Search", PurchaseInvoiceManager.BindDataGrid());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult AddEditPurchaseReturn(int id = 0)
        {
            try
            {
                PurchaseReturnModel ret = new PurchaseReturnModel();

                if (id > 0)
                {
                    ret = PurchaseInvoiceManager.GetPurchaseReturnDetail((Int64)id);
                }
                PurchaseInvoiceManager.InitializeAddEdit(ret);
                return View(ret);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPost]
        public ActionResult AddEditPurchaseReturn(PurchaseReturnModel ret)
        {
            try
            {
                ret = PurchaseInvoiceManager.InsertUpdatePurchaseReturn(ret);
                PurchaseInvoiceManager.InitializeAddEdit(ret);
                return View(ret);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public JsonResult BindTempGrid(Int64 invId)
        {
            try
            {
                return Json(PurchaseInvoiceManager.GetPurchaseInvDetail(invId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public JsonResult GetTotalQuantity(Int64 detailId)
        {
            try
            {
                return Json(PurchaseInvoiceManager.GetTotalQuantity(detailId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public JsonResult DeleteItem(Int64 id, string status)
        {
            var returnValues = new object();
            try
            {
                PurchaseInvoiceManager.DeleteRecord(id);
                returnValues = new { Message = "Record deleted Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
            }
            catch (Exception ex)
            {
                returnValues = new { Message = ex.Message.ToString(), MessageType = (int)Utilities.Enums.Message.Success };
            }
            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PurchaseReturnReport(int id)
        {
            try
            {
                PurchaseReturnReportViewModel model = new PurchaseReturnReportViewModel();
                model.DetailList = PurchaseInvoiceManager.GetPurchaseReturnDetail(id);
                var data = PurchaseInvoiceManager.GetPurchaseReturnById(id);
                model.Date = Convert.ToDateTime(data.Date).ToString("dd-MMM-yyyy");
                model.InvoiceDate = Convert.ToDateTime(data.InvoiceDate).ToString("dd-MMM-yyyy");
                model.InvoiceNo = data.InvoiceNo;
                model.ReturnNo = data.ReturnNo;
                model.Supplier = SupplierMasterManager.GetDataById((Int64)data.SupplierId).SupplierName;
                ViewBag.ReportTitle = "Purchase Return Report";
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}