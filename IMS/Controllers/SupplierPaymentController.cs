using ClosedXML.Excel;
using IMS.Business;
using IMS.DataContext;
using IMS.Filters;
using IMS.Models.SupplierPayment;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IMS.Controllers
{
    [CustomAuthorizationFilter]
    public class SupplierPaymentController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        public ActionResult Index()
        {
            SupplierPaymentReportViewModel M = new SupplierPaymentReportViewModel();
            M.SupplierList = CommonClass.GetSupplierList();
            return View(M);
        }

        public ActionResult SearchSupplierPayment()
        {
            try
            {
                List<SupplierPayment> model = SupplierPaymentManager.GetAllDetail();
                return View("_SearchSupplierPayment", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult AddEditSupplierPayment(Int32 id = 0)
        {
            try
            {
                SupplierPaymentModel m = new SupplierPaymentModel();
                if (id > 0)
                {
                    SupplierPayment model = new SupplierPayment();
                    model = SupplierPaymentManager.GetDataById(id);
                    m.SupplierName = model.SuppilerId;
                    m.PaymentAmount = model.PaymentAmount;
                    m.PaymentNumber = model.PaymentNo;
                    m.PaymentDate = model.PaymentDate;
                    m.TotalDue = model.TotalDue;
                    m.TotalPaid = model.TotalPaid;
                    m.Description = model.Description;
                    m.IsDeleted = model.IsDeleted;
                    m.IsPosted = Convert.ToString(model.IsPosted);
                    m.Id = model.Id; 
                }
                SupplierPaymentManager.BindDropDown(m);
                return View(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditSupplierPayment(SupplierPaymentModel spm)
        {
            var returnValues = new object();
            try
            {
                if (spm.Id > 0)
                {
                    var model = SupplierPaymentManager.UpdateSupplierPayment(spm);
                    spm.Status = 3;
                    spm.StatusMessage = "Payment Updated Successfully.";
                }
                else
                {
                    var hed = SupplierPaymentManager.InsertIntoSupplierPayment(spm);
                    spm.Status = 1;
                    spm.StatusMessage = "Payment Added Successfully.";                    
                }
                SupplierPaymentReportViewModel M = new SupplierPaymentReportViewModel();
                M.SupplierList = CommonClass.GetSupplierList();
                return View("Index", M);                
            }
            catch (Exception ex)
            {
                returnValues = new { Message = ex.Message, MessageType = (int)Utilities.Enums.Message.Error };
            }
            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteItem(Int64 id, string status)
        {
            var returnValues = new object();
            try
            {
                string message = "";
                SupplierPaymentManager.DeleteAndPostRecord(id, status);
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
        public JsonResult GetSupplierDetail(Int64 id = 0)
        {
            return Json(SupplierPaymentManager.GetSupplierDetailById(id), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult SupplierPaymentReport(int id)
        {
            try
            {
                SupplierPaymentReportViewModel model = new SupplierPaymentReportViewModel();
                var hed = SupplierPaymentManager.GetSupplierPaymentById(id);
                model.PaymentDate = hed.PaymentDate.ToString("dd-MMM-yyyy");
                model.PaymentNo = hed.PaymentNo;
                model.SupplierName = SupplierMasterManager.GetDataById((Int64)hed.SuppilerId).SupplierName;
                model.TotalDue = hed.TotalDue;
                model.TotalPaid = hed.TotalPaid;
                model.PaymentAmount = hed.PaymentAmount;
                model.Description = hed.Description;
                
                ViewBag.ReportTitle = "Supplier Payment Note";
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult PurchaseInvoiceReport(int supplierId = 0, string FromDate = "", string ToDate = "", string supplierName = "")
        {
            try
            {
                string FilterCriteria = "";
                string SQL = "";
                if (supplierName != "")
                {
                    FilterCriteria += "<b>Supplier Name: </b>" + supplierName + " &nbsp;&nbsp;&nbsp;&nbsp;";
                }
                if (FromDate != "")
                {
                    FilterCriteria += "<b>From Date: </b>" + FromDate + " &nbsp;&nbsp;&nbsp;&nbsp;";
                }
                if (ToDate != "")
                {
                    FilterCriteria += "<b>To Date: </b>" + ToDate + " &nbsp;&nbsp;&nbsp;&nbsp;";
                }
                
                if (FilterCriteria != "")
                {
                    ViewBag.Searchcriteria = FilterCriteria;
                }

                SQL = @" select isnull(OpeningBalance,0) as OpeningBalance from SupplierMaster where Id = " + supplierId;
                ViewBag.OpeningBalance = Convert.ToDecimal(DbUtility.ExecuteScalarGetItem(SQL));

                SQL = @" select isnull(SUM(PaymentAmount),0) as PaymentAmount from SupplierPayment where SuppilerId = "+ supplierId + " and IsDeleted = 0 ";
                ViewBag.TotalPaidAmount = Convert.ToDecimal(DbUtility.ExecuteScalarGetItem(SQL));

                SQL = @" select PIH.PurchaseInvHeadId as Id, PIH.Date as InvoiceDate, PIH.InvoiceNo, 
                        isnull((PIH.FinalAmount + PIH.ExtraAmount - PIH.Discount), 0) as totalamount, isnull(PIH.PaidAmount, 0) as PaidAmount
                        from PurchaserInvoiceHeader PIH inner join SupplierMaster SM on SM.Id = PIH.SupplierID where PIH.SupplierID = " + supplierId + @" 
                        and PIH.IsDeleted = 0 and PIH.IsPosted = 1 and PIH.InvoiceType = " + (int)Utilities.Enums.InvoiceType.Credit+ @" ";
                if (FromDate != "")
                {
                    SQL += "  ";
                }
                if (ToDate != "")
                {
                    SQL += "  ";
                }
                List<DataRow> List = null;
                List = DbUtility.GetDataTable(new SqlCommand() { CommandText = SQL }).AsEnumerable().ToList();
                ViewBag.result = List;
                ViewBag.cnt = List.Count();
                
                ViewBag.ReportTitle = "Purchase Invoice Report";
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult PaymentSummaryReport(int supplierId = 0, string FromDate = "", string ToDate = "", string supplierName = "")
        {
            try
            {
                string FilterCriteria = "";
                string SQL = "";
                if (supplierName != "")
                {
                    FilterCriteria += "<b>Supplier Name: </b>" + supplierName + " &nbsp;&nbsp;&nbsp;&nbsp;";
                }
                if (FromDate != "")
                {
                    FilterCriteria += "<b>From Date: </b>" + FromDate + " &nbsp;&nbsp;&nbsp;&nbsp;";
                }
                if (ToDate != "")
                {
                    FilterCriteria += "<b>To Date: </b>" + ToDate + " &nbsp;&nbsp;&nbsp;&nbsp;";
                }

                if (FilterCriteria != "")
                {
                    ViewBag.Searchcriteria = FilterCriteria;
                }

                if (supplierId > 0)
                {
                    SQL = @" select isnull(OpeningBalance,0) as OpeningBalance from SupplierMaster where Id = " + supplierId;
                    ViewBag.OpeningBalance = Convert.ToDecimal(DbUtility.ExecuteScalarGetItem(SQL));
                }

                SQL = @" select t.SuppilerId, t.SupplierName, SUM(t.DueAmount) as DueAmount, SUM(t.PaymentAmount) as PaymentAmount from 
                        ( select SuppilerId, SupplierName, 0 as DueAmount, sum(PaymentAmount) as PaymentAmount from SupplierPayment SP 
                        inner join SupplierMaster SM on SP.SuppilerId = SM.Id where SP.IsDeleted = 0 ";
                if (supplierId > 0)
                {
                    SQL += " and SM.Id = " + supplierId;
                }
                if (FromDate != "")
                {
                    SQL += "  ";
                }
                if (ToDate != "")
                {
                    SQL += "  ";
                }

                SQL += " group by SuppilerId, SupplierName, SM.OpeningBalance union ";

                SQL += @" select SM.Id, SM.SupplierName, (isnull(SUM(FinalAmount),0) - isnull(SUM(Discount),0) + isnull(SUM(ExtraAmount),0) - isnull(SUM(PaidAmount),0)) + SM.OpeningBalance as DueAmount, 
                          0 as PaymentAmount from PurchaserInvoiceHeader PIH inner join SupplierMaster SM on PIH.SupplierID = SM.Id 
                          where PIH.IsDeleted = 0 and PIH.IsPosted = 1 ";
                if (supplierId > 0)
                {
                    SQL += " and SM.Id = " + supplierId;
                }
                if (FromDate != "")
                {
                    SQL += "  ";
                }
                if (ToDate != "")
                {
                    SQL += "  ";
                }
                SQL += " group by SM.Id, SM.SupplierName, SM.OpeningBalance)t group by t.SuppilerId, t.SupplierName ";

                List<DataRow> List = null;
                List = DbUtility.GetDataTable(new SqlCommand() { CommandText = SQL }).AsEnumerable().ToList();
                ViewBag.result = List;
                ViewBag.cnt = List.Count();

                ViewBag.ReportTitle = "Payment Summary Report";
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}