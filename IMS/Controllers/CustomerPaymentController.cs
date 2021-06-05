using ClosedXML.Excel;
using IMS.Business;
using IMS.DataContext;
using IMS.Filters;
using IMS.Models.CustomerPayment;
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
    public class CustomerPaymentController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        public ActionResult Index()
        {
            CustomerPaymentReportViewModel M = new CustomerPaymentReportViewModel();
            M.CustomerList = CommonClass.GetCustomerList();
            return View(M);
        }

        public ActionResult SearchCustomerPayment()
        {
            try
            {
                List<CustomerPayment> model = CustomerPaymentManager.GetAllDetail();
                return View("_SearchCustomerPayment", model);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpGet]
        public ActionResult AddEditCustomerPayment(Int32 id = 0)
        {
            try
            {
                CustomerPaymentModel m = new CustomerPaymentModel();
                if (id > 0)
                {
                    CustomerPayment model = new CustomerPayment();
                    model = CustomerPaymentManager.GetDataById(id);
                    m.CustomerName = model.CustomerId;
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
                CustomerPaymentManager.BindDropDown(m);
                return View(m);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditCustomerPayment(CustomerPaymentModel spm)
        {
            var returnValues = new object();
            try
            {
                if (spm.Id > 0)
                {
                    var model = CustomerPaymentManager.UpdateCustomerPayment(spm);
                    spm.Status = 3;
                    spm.StatusMessage = "Payment Updated Successfully.";
                }
                else
                {
                    var hed = CustomerPaymentManager.InsertIntoCustomerPayment(spm);
                    spm.Status = 1;
                    spm.StatusMessage = "Payment Added Successfully.";                    
                }
                CustomerPaymentReportViewModel M = new CustomerPaymentReportViewModel();
                M.CustomerList = CommonClass.GetCustomerList();
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
                CustomerPaymentManager.DeleteAndPostRecord(id, status);
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
        public JsonResult GetCustomerDetail(Int64 id = 0)
        {
            return Json(CustomerPaymentManager.GetCustomerDetailById(id), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult CustomerPaymentReport(int id)
        {
            try
            {
                CustomerPaymentReportViewModel model = new CustomerPaymentReportViewModel(); 
                var hed = CustomerPaymentManager.GetCustomerPaymentById(id);
                model.PaymentDate = hed.PaymentDate.ToString("dd-MMM-yyyy");
                model.PaymentNo = hed.PaymentNo;
                model.CustomerName = CustomerMasterManager.GetDataById((Int64)hed.CustomerId).CustomerName;
                model.TotalDue = hed.TotalDue;
                model.TotalPaid = hed.TotalPaid;
                model.PaymentAmount = hed.PaymentAmount;
                model.Description = hed.Description;
                
                ViewBag.ReportTitle = "Customer Payment Note";
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult SaleInvoiceReport(int customerId = 0, string FromDate = "", string ToDate = "", string customerName = "")
        {
            try
            {
                string FilterCriteria = "";
                string SQL = "";
                if (customerName != "")
                {
                    FilterCriteria += "<b>Customer Name: </b>" + customerName + " &nbsp;&nbsp;&nbsp;&nbsp;";
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

                SQL = @" select isnull(OpeningBalance,0) as OpeningBalance from CustomerMaster where Id = " + customerId;
                ViewBag.OpeningBalance = Convert.ToDecimal(DbUtility.ExecuteScalarGetItem(SQL));

                SQL = @" select isnull(SUM(PaymentAmount),0) as PaymentAmount from CustomerPayment where CustomerId = " + customerId + " and IsDeleted = 0 ";
                ViewBag.TotalPaidAmount = Convert.ToDecimal(DbUtility.ExecuteScalarGetItem(SQL));

                SQL = @" select PIH.Id, PIH.Date as InvoiceDate, PIH.InvoiceNo, isnull(PIH.FinalAmount,0) as totalamount, isnull(PIH.PaidAmount,0) as PaidAmount
                        from SalesInvoice PIH inner join CustomerMaster SM on SM.Id = PIH.CustomerId where PIH.CustomerId = " + customerId + @"
                        and PIH.IsDeleted = 0 and PIH.IsPosted = 1 and PIH.InvoiceType = " + (int)Utilities.Enums.InvoiceType.Credit + @" ";
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

                ViewBag.ReportTitle = "Sale Invoice Report";
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult PaymentSummaryReport(int customerId = 0, string FromDate = "", string ToDate = "", string customerName = "")
        {
            try
            {
                string FilterCriteria = "";
                string SQL = "";
                if (customerName != "")
                {
                    FilterCriteria += "<b>Customer Name: </b>" + customerName + " &nbsp;&nbsp;&nbsp;&nbsp;";
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

                if (customerId > 0)
                {
                    SQL = @" select isnull(OpeningBalance,0) as OpeningBalance from CustomerMaster where Id = " + customerId;
                    ViewBag.OpeningBalance = Convert.ToDecimal(DbUtility.ExecuteScalarGetItem(SQL));
                }

                SQL = @" select t.CustomerId, t.CustomerName, SUM(t.DueAmount) as DueAmount, SUM(t.PaymentAmount) as PaymentAmount from 
                        ( select CustomerId, CustomerName, 0 as DueAmount, sum(PaymentAmount) as PaymentAmount from CustomerPayment SP 
                        inner join CustomerMaster SM on SP.CustomerId = SM.Id where SP.IsDeleted = 0 ";
                if (customerId > 0)
                {
                    SQL += " and SM.Id = " + customerId;
                }
                if (FromDate != "")
                {
                    SQL += "  ";
                }
                if (ToDate != "")
                {
                    SQL += "  ";
                }

                SQL += " group by CustomerId, CustomerName, SM.OpeningBalance union ";

                SQL += @" select SM.Id, SM.CustomerName, (isnull(SUM(FinalAmount),0) - isnull(SUM(PaidAmount),0)) + SM.OpeningBalance as DueAmount, 
                          0 as PaymentAmount from SalesInvoice PIH inner join CustomerMaster SM on PIH.CustomerID = SM.Id 
                          where PIH.IsDeleted = 0 and PIH.IsPosted = 1 ";
                if (customerId > 0)
                {
                    SQL += " and SM.Id = " + customerId;
                }
                if (FromDate != "")
                {
                    SQL += "  ";
                }
                if (ToDate != "")
                {
                    SQL += "  ";
                }
                SQL += " group by SM.Id, SM.CustomerName, SM.OpeningBalance)t group by t.CustomerId, t.CustomerName ";

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