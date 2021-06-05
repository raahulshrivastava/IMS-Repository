
using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.Business
{
    public class CustomerPaymentManager
    {
        public static List<CustomerPayment> GetAllDetail()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    List<CustomerPayment> model = db.CustomerPayments.Where(a => a.IsDeleted == 0).OrderByDescending(a => a.PaymentDate).AsNoTracking().ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static CustomerPayment InsertIntoCustomerPayment(CustomerPaymentModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    CustomerPayment m = new CustomerPayment();
                    m.CustomerId = model.CustomerName;
                    m.PaymentDate = Convert.ToDateTime(model.PaymentDate);
                    m.PaymentAmount = model.PaymentAmount;
                    m.Description = model.Description;
                    m.TotalDue = model.hdnTotalDue;
                    m.TotalPaid = model.hdnTotalPaid;
                    Int32 incrementno = db.CustomerPayments.AsNoTracking().OrderByDescending(a => a.IncrementNo).Select(a => a.IncrementNo).FirstOrDefault();
                    var prefix = db.PrefixMasters.AsNoTracking().Where(a => a.PrefixName.ToUpper() == "CPN").Select(a => new { a.PrefixName, a.StartingFrom }).FirstOrDefault();
                    m.PaymentNo = prefix.PrefixName + (int.Parse(prefix.StartingFrom) + incrementno + 1);
                    m.IncrementNo = incrementno + 1;
                    m.IsDeleted = 0;
                    m.IsPosted = 0;

                    m.StoreId = UserSession.StoreId;
                    m.FinancialId = int.Parse(UserSession.FinYear);
                    m.CreatedBy = UserSession.Id;
                    m.CreatedOn = DateTime.Now;
                    db.CustomerPayments.Add(m);
                    db.SaveChanges();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static CustomerPayment GetCustomerPaymentById(Int64 id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.CustomerPayments.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertIntoCustomerPayment(List<CustomerPayment> category)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    db.CustomerPayments.AddRange(category);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static CustomerPaymentModel UpdateCustomerPayment(CustomerPaymentModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    CustomerPayment exitdata = db.CustomerPayments.AsNoTracking().Where(a => a.Id == model.Id).FirstOrDefault();

                    exitdata.CustomerId = model.CustomerName;
                    exitdata.PaymentDate = model.PaymentDate;
                    exitdata.PaymentAmount = model.PaymentAmount;
                    exitdata.Description = model.Description;
                    exitdata.ModifiedBy = UserSession.Id;
                    exitdata.ModifiedOn = DateTime.Now.Date;
                    exitdata.TotalDue = model.hdnTotalDue;
                    exitdata.TotalPaid = model.hdnTotalPaid;
                    exitdata.IsDeleted = 0;
                    exitdata.IsPosted = 0;

                    db.Entry(exitdata).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public static CustomerPayment GetDataById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    CustomerPayment model = db.CustomerPayments.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void DeleteAndPostRecord(Int64 id, string status)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var T = db.CustomerPayments.Where(a => a.Id == id).FirstOrDefault();
                    if (status == "d") { T.IsDeleted = 1; }
                    else { T.IsPosted = 1; }
                    T.ModifiedBy = (int)UserSession.Id;
                    T.ModifiedOn = DateTime.Now.Date;
                    db.Entry(T).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void BindDropDown(CustomerPaymentModel M)
        {
            try
            {
                M.BindCustomerList = CommonClass.GetCustomerList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetCustomerDetailById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    string det = "";
                    string query = "";

                    query = $" select isnull(SUM(FinalAmount),0) as totalamount, isnull(sum(PaidAmount),0) as PaidAmount from SalesInvoice where IsPosted = 1 and IsDeleted = 0 and InvoiceType = {(int)Utilities.Enums.InvoiceType.Credit} and CustomerID = {id} ";
                    DataTable dtAmount = DbUtility.GetDataTable(new SqlCommand() { CommandText = query });
                    query = $" select ISNULL(SUM(PaymentAmount),0) as PaidAmount from CustomerPayment where IsDeleted = 0 and CustomerId = {id} ";
                    decimal PaidAmount = Convert.ToDecimal(DbUtility.ExecuteScalarGetItem(query));
                    query = $" select ISNULL(OpeningBalance,0) as OpeningBalance from CustomerMaster where Id = {id} ";
                    decimal OpeningBalance = Convert.ToDecimal(DbUtility.ExecuteScalarGetItem(query));

                    var TotalDue = OpeningBalance + Convert.ToDecimal(dtAmount.Rows[0]["totalamount"]) - Convert.ToDecimal(dtAmount.Rows[0]["PaidAmount"]);
                    var TotalPaid = PaidAmount;
                    var TotalRemaining = Convert.ToDecimal(TotalDue) - Convert.ToDecimal(TotalPaid);
                    
                    det = Convert.ToString(TotalDue);
                    det += "!" + Convert.ToString(TotalPaid);
                    det += "!" + Convert.ToString(TotalRemaining);
                    det += "!" + Convert.ToString(OpeningBalance);
                    return det;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public partial class CustomerPaymentModel
    {
        public long Id { get; set; }
        public Nullable<int> SaleInvoiceId { get; set; }
        public int CustomerId { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentNumber { get; set; }
        public string Description { get; set; }
        public System.DateTime PaymentDate { get; set; }

        public Nullable<int> IsDeleted { get; set; }
        public SelectList BindCustomerList { get; set; }
        public Int32 CustomerName { get; set; }
        public decimal TotalDue { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal TotalRemaining { get; set; }
        public decimal OpeningBalance { get; set; }
        public int Status { get; set; }
        public string StatusMessage { get; set; }
        public string IsPosted { get; set; }
        public decimal hdnTotalDue { get; set; }
        public decimal hdnTotalPaid { get; set; }
    }
}