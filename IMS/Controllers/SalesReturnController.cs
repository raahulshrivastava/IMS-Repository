using ClosedXML.Excel;
using IMS.Business;
using IMS.DataContext;
using IMS.Filters;
using IMS.Models.SalesReturn;
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
    public class SalesReturnController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        public ActionResult Index()
        {
            return View();
        }

        //[ChildActionOnly]
        public ActionResult SearchSalesReturn()
        {
            try
            {
                return PartialView("_SearchSalesReturn", SalesManager.BindDataGrid());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public ActionResult AddEditSalesReturn(int id = 0)
        {
            try
            {
                SalesReturnModel ret = new SalesReturnModel();

                if (id > 0)
                {
                    ret = SalesManager.GetSalesReturnDetail(id);
                    if (!string.IsNullOrEmpty(Convert.ToString(TempData["Status"])) && !string.IsNullOrEmpty(Convert.ToString(TempData["StatusId"])))
                    {
                        ret.Status = Convert.ToString(TempData["Status"]);
                        ret.StatusId = Convert.ToInt32(TempData["StatusId"]);
                    }
                }
                SalesManager.InitializeAddEdit(ret);
                return View(ret);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpPost]
        public ActionResult AddEditSalesReturn(SalesReturnModel ret)
        {
            try
            {
                ret = SalesManager.InsertUpdateSalesReturn(ret);
                SalesManager.InitializeAddEdit(ret);
                TempData["Status"] = ret.Status;
                TempData["StatusId"] = ret.StatusId;

                return RedirectToAction("AddEditSalesReturn", new { id = ret.SalesReturnHeaderId });
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
                return Json(SalesManager.GetSalesInvDetail(invId), JsonRequestBehavior.AllowGet);
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
                return Json(SalesManager.GetTotalQuantity(detailId), JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public JsonResult DeleteSalesReturnItem(Int64 id, string status)
        {
            var returnValues = new object();
            try
            {
                SalesManager.DeleteRecord(id);
                returnValues = new { Message = "Record deleted Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
            }
            catch (Exception ex)
            {
                returnValues = new { Message = ex.Message.ToString(), MessageType = (int)Utilities.Enums.Message.Success };
            }
            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }



        public ActionResult SalesReturnReport(Int64 id)
        {
            try
            {
                SalesReturnReportViewModel model = new SalesReturnReportViewModel();
                var hed = SalesManager.GetSalesInvoiceReturnHeaderById(id);
                var det = SalesManager.GetSalesReturnDetails(id);
                model.CustomerName = CustomerMasterManager.GetDataById((Int64)hed.CustomerId).CustomerName;
                model.Date = hed.Date.Value.ToString("dd-MMM-yyyy");
                model.InvoiceDate = hed.InvoiceDate.Value.ToString("dd-MMM-yyyy");
                model.InvoiceNo = hed.InvoiceNo;
                model.ReturnNo = hed.ReturnNo;
                model.DetailList = new List<SalesReturnDetail>();
                foreach (var d in det)
                {
                    SalesReturnDetail item = new SalesReturnDetail();
                    item.FreeQuantity = d.FreeQuantity.ToString(); ;
                    item.Product = ProductMasterManager.GetValuesHeaderById((Int64)d.ProductId).ProductName;
                    item.Quantity = d.Quantity.ToString();
                    item.ReturnQuantity = d.ReturnQuantity.ToString();
                    item.TotalQuantity = d.TotalQuantity.ToString();
                    model.DetailList.Add(item);
                }
                ViewBag.ReportTitle = "SalesReturnReport";
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}