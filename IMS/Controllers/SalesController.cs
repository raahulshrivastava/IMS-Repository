using ClosedXML.Excel;
using IMS.Business;
using IMS.DataContext;
using IMS.Filters;
using IMS.Models;
using IMS.Models.SalesInvoices;
using IMS.Models.SalesReturn;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using static IMS.Utilities.Enums;

namespace IMS.Controllers
{
    [CustomAuthorizationFilter]
    public class SalesController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SeachSales()
        {
            return PartialView("_SeachSales", SalesManager.GetAllDeatil());
        }

        [HttpGet]
        public ActionResult AddEditSales(int id = 0)
        {
            try
            {
                SalesInvoiceModel Sales = new SalesInvoiceModel();
                if (id > 0)
                {
                    Sales = SalesManager.GetSalesDetailById(id);
                }
                else
                {
                    Sales.IsPosted = "0";
                    Sales.Status = 0.ToString();
                    Sales.StatusMessage = "";
                }
                InitializeDropDown(Sales);
                
                return View(Sales);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditSales(SalesInvoiceModel salesModel)
        {
            SalesManager.InsertUpdateSalesInvoice(salesModel);
            salesModel.ShowHideBatchExpiry = CommonClass.GetConfiguration();
            InitializeDropDown(salesModel);
            return View("Index");
        }

        public void InitializeDropDown(SalesInvoiceModel salesModel)
        {
            salesModel.CategoryList = CommonClass.GetCategoryList();
            salesModel.CustomerList = CommonClass.GetCustomerList();
            salesModel.InvoiceTypeList = CommonClass.BindInvoiceType();
        }

        public JsonResult GetStockInDetails(Int64 productId)
        {
            return Json(SalesManager.GetSalesDetailsByProductId(productId), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteItem(Int64 id, string status)
        {
            var returnValues = new object();
            try
            {
                string message = "";
                SalesManager.DeleteAndPostRecord(id, status);
                if (status == "d") { message = "Record deleted Successfully."; }
                else { message = "Record Posted Successfully."; }
                returnValues = new { Message = message, MessageType = (int)Utilities.Enums.Message.Success };
            }
            catch (Exception ex)
            {
                returnValues = new { Message = ex.Message.ToString(), MessageType = (int)Utilities.Enums.Message.Success };
            }
            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SalesInvoiceReport(Int64 id)
        {
            try
            {
                SalesInvoiceReportViewModel model = new SalesInvoiceReportViewModel();
                var salesInvoice = SalesManager.GetSalesInvoice(id);
                var det = SalesManager.GetSalesInvoiceDetailsById(id);
                model.Date = salesInvoice.Date.ToString("dd-MMM-yyyy");
                model.CustomerName = salesInvoice.CustomerName;
                model.Discount = salesInvoice.Discount;
                model.ExtraAmount = salesInvoice.ExtraAmount;
                model.FinalAmount = salesInvoice.FinalAmount;
                model.PaidAmount = salesInvoice.PaidAmount;
                model.SalesInvoiceNumber = salesInvoice.InvoiceNo;
                model.SalesInvoiceType = Enum.GetName(typeof(InvoiceType), int.Parse(salesInvoice.InvoiceType));
                model.TotalAmount = salesInvoice.TotalAmount;
                model.TotalCGST = salesInvoice.TotalCGST;
                model.TotalIGST = salesInvoice.TotalIGST;
                model.TotalSGST = salesInvoice.TotalSGST;
                model.TotalTaxAmount = salesInvoice.TotalTaxAmount;
                model.DetailList = new List<SalesInvoiceDetailList>();
                foreach (var i in det)
                {
                    SalesInvoiceDetailList item = new SalesInvoiceDetailList();
                    var product = ProductMasterManager.GetValuesHeaderById(i.ProductId);
                    var unit = UnitMasterManager.GetDataById(product.UnitId);
                    item.ProductName = product.ProductName;
                    item.ProductId = i.ProductId;
                    item.UnitName = unit.UnitName;
                    item.Quantity = i.Quantity;
                    item.TotalAmount = i.TotalAmount;
                    item.Discount = i.Discount;
                    item.TaxableAmount = i.TaxableAmount;
                    item.CGSTAmount = i.CGSTAmount;
                    item.SGSTAmount = i.SGSTAmount;
                    item.IGSTAmount = i.IGSTAmount;
                    item.GrossAmount = i.GrossAmount;
                    item.FreeQuantity = i.FreeQuantity;
                    item.TotalQauntity = i.TotalQauntity;
                    item.Price = i.Price;
                    item.MPR = i.MPR;
                    item.CGSTPercentage = i.CGSTPercentage;
                    item.SGSTPercent = i.SGSTPercent;
                    item.IGSTPercentage = i.IGSTPercentage;
                    item.GstType = (i.IGSTAmount == 0 ? "GST" : "IGST");
                    if (UserSession.StoreType == 0)
                    {
                        item.BatchNo = i.BatchNo;
                        item.ExpiryDate = i.ExpiryDate.Value.ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        item.BatchNo = "";
                        item.ExpiryDate = null;
                    }
                    model.DetailList.Add(item);
                }
                ViewBag.ReportTitle = "Sales Invoice Report";
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}