using ClosedXML.Excel;
using IMS.Business;
using IMS.DataContext;
using IMS.Filters;
using IMS.Models.PurchaseInvoice;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using System.Web.Mvc;
using System.Web.Script.Serialization;
using static IMS.Utilities.Enums;

namespace IMS.Controllers
{
    [CustomAuthorizationFilter]
    public class PurchaseInvoiceController : Controller
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
                var T = PurchaseInvoiceManager.GetAllDeatil();
                return PartialView("_Search", T);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult AddEditPurchaseInvoice(int id = 0)
        {
            try
            {
                PurchaseInvModel inv = new PurchaseInvModel();

                if (id > 0)
                {
                    inv = PurchaseInvoiceManager.GetInvoiceDetailById(id);
                    inv.Status = 2;
                }
                else
                {
                    inv.IsPosted = "0";
                    inv.Status = 0;
                    inv.StatusMessage = "";
                }
                PurchaseInvoiceManager.BindDropDown(inv);
                return View(inv);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditPurchaseInvoice(PurchaseInvModel inv)
        {
            try
            {
                if (inv.PurchaserInvHeaderId > 0)
                {
                    var model = PurchaseInvoiceManager.UpdateInvoice(inv);
                    inv.Status = 3;
                    inv.StatusMessage = "Invoice Updated Successfully.";
                    PurchaseInvoiceManager.BindDropDown(inv);
                }
                else
                {
                    var hed = PurchaseInvoiceManager.InsertIntoPurchaseInvHeader(inv);
                    inv.Status = 1;
                    inv.StatusMessage = "Invoice Added Successfully.";
                    PurchaseInvoiceManager.BindDropDown(inv);
                }
                return View("Index");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public JsonResult GetProductDetail(Int64 id = 0)
        {
            return Json(PurchaseInvoiceManager.GetProductDetailById(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteItem(Int64 id, string status)
        {
            var returnValues = new object();
            try
            {
                string message = "";
                PurchaseInvoiceManager.DeleteAndPostRecord(id, status);
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

        [HttpGet]
        public ActionResult PurchaseInvoiceReport(int id)
        {
            try
            {
                PurchaseInvoiceReportViewModel model = new PurchaseInvoiceReportViewModel();
                var hed = PurchaseInvoiceManager.GetPurchaserInvoiceHeaderById(id);
                model.Date = hed.Date.ToString("dd-MMM-yyyy");
                model.SupplierBillDate = hed.SupplierBillDate.ToString("dd-MMM-yyyy");
                model.SupplierBillNo = hed.SupplierBillNo;
                model.SupplierName = SupplierMasterManager.GetDataById((Int64)hed.SupplierID).SupplierName;
                model.InvoiceNo = hed.InvoiceNo;
                model.InvoiceType = System.Enum.GetName(typeof(InvoiceType), int.Parse(hed.InvoiceType));
                model.TotalCGST = hed.TotalCGST;
                model.TotalSGST = hed.TotalSGST;
                model.TotalIGST = hed.TotalIGST;
                model.TotalTaxAmount = hed.TotalTaxAmount;
                model.TotalAmount = hed.TotalAmount;
                model.Discount = hed.Discount;
                model.ExtraAmount = hed.ExtraAmount ?? decimal.Zero;
                model.FinalAmount = hed.FinalAmount;
                model.PaidAmount = hed.PaidAmount;

                var detail = PurchaseInvoiceManager.GetPurchaseInvoiceDetailById(id);
                foreach (var i in detail)
                {
                    PurchaseInvoiceDetailList item = new PurchaseInvoiceDetailList();
                    var product = ProductMasterManager.GetValuesHeaderById(i.ProductId);
                    var unit = UnitMasterManager.GetDataById(product.UnitId);
                    item.ProductName = product.ProductName;
                    item.ProductId = i.ProductId;
                    item.UnitName = unit.UnitName;
                    item.Quantity = i.Quantity;
                    item.Price = i.Price;
                    item.TotalAmount = i.TotalAmount;
                    item.Discount = i.Discount;
                    item.TaxableAmount = i.TaxableAmount;
                    item.CGSTAmount = i.CGSTAmount;
                    item.SGSTAmount = i.SGSTAmount;
                    item.IGSTAmount = i.IGSTAmount;
                    item.GrossAmount = i.GrossAmount;
                    item.FreeQuantity = i.FreeQuantity;
                    item.TotalQauntity = i.TotalQauntity;
                    item.ChallanNo = i.ChallanNo;
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
                ViewBag.ReportTitle = "Purchase Invoice Report";
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}