
using IMS.DataContext;
using IMS.Models.SupplierPayment;
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
    public class SupplierPaymentManager
    {
        public static List<SupplierPayment> GetAllDetail()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    List<SupplierPayment> model = db.SupplierPayments.Where(a => a.IsDeleted == 0).OrderByDescending(a => a.PaymentDate).AsNoTracking().ToList();
                    return model;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static SupplierPayment InsertIntoSupplierPayment(SupplierPaymentModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    SupplierPayment m = new SupplierPayment();
                    m.SuppilerId = model.SupplierName;
                    m.PaymentDate = Convert.ToDateTime(model.PaymentDate);
                    m.PaymentAmount = model.PaymentAmount;
                    m.Description = model.Description;
                    m.TotalDue = model.hdnTotalDue;
                    m.TotalPaid = model.hdnTotalPaid;
                    Int32 incrementno = db.SupplierPayments.AsNoTracking().OrderByDescending(a => a.IncrementNo).Select(a => a.IncrementNo).FirstOrDefault();
                    var prefix = db.PrefixMasters.AsNoTracking().Where(a => a.PrefixName.ToUpper() == "SPN").Select(a => new { a.PrefixName, a.StartingFrom }).FirstOrDefault();
                    m.PaymentNo = prefix.PrefixName + (int.Parse(prefix.StartingFrom) + incrementno + 1);
                    m.IncrementNo = incrementno + 1;
                    m.IsDeleted = 0;
                    m.IsPosted = 0;

                    m.StoreId = UserSession.StoreId;
                    m.FinancialId = int.Parse(UserSession.FinYear);
                    m.CreatedBy = UserSession.Id;
                    m.CreatedOn = DateTime.Now;
                    db.SupplierPayments.Add(m);
                    db.SaveChanges();
                    return m;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SupplierPayment GetSupplierPaymentById(Int64 id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.SupplierPayments.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertIntoSupplierPayment(List<SupplierPayment> category)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    db.SupplierPayments.AddRange(category);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SupplierPaymentModel UpdateSupplierPayment(SupplierPaymentModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    SupplierPayment exitdata = db.SupplierPayments.AsNoTracking().Where(a => a.Id == model.Id).FirstOrDefault();

                    exitdata.SuppilerId = model.SupplierName;
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
        
        public static SupplierPayment GetDataById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    SupplierPayment model = db.SupplierPayments.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
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
                    var T = db.SupplierPayments.Where(a => a.Id == id).FirstOrDefault();
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

        public static void BindDropDown(SupplierPaymentModel M)
        {
            try
            {
                M.BindSupplierList = CommonClass.GetSupplierList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetSupplierDetailById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    string det = "";
                    string query = "";

                    query = $" select isnull((SUM(PIH.FinalAmount) + SUM(PIH.ExtraAmount) - SUM(PIH.Discount)),0) as totalamount, isnull(sum(PIH.PaidAmount),0) as PaidAmount from PurchaserInvoiceHeader PIH where PIH.IsPosted = 1 and PIH.IsDeleted = 0 and PIH.InvoiceType = {(int)Utilities.Enums.InvoiceType.Credit} and PIH.SupplierID = {id} ";
                    DataTable dtAmount = DbUtility.GetDataTable(new SqlCommand() { CommandText = query });
                    query = $" select ISNULL(SUM(PaymentAmount),0) as PaidAmount from SupplierPayment where IsDeleted = 0 and SuppilerId = {id} ";
                    decimal PaidAmount = Convert.ToDecimal(DbUtility.ExecuteScalarGetItem(query));
                    query = $" select ISNULL(OpeningBalance,0) as OpeningBalance from SupplierMaster where Id = {id} ";
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

        //public static List<SupplierPaymentReportViewModel> GetPurchaseInvoiceDetail(int supplierId = 0, string FromDate = "", string ToDate = "")
        //{
        //    using (var db = new IMSContext())
        //    {
        //        var query = (from hd in db.ProductMasterHeaders.AsNoTracking()
        //                     join bd in db.BrandMasters.AsNoTracking() on hd.BrandId equals bd.Id
        //                     join ct in db.CategoryMasters.AsNoTracking() on hd.CategoryId equals ct.Id
        //                     join ut in db.UnitMasters.AsNoTracking() on hd.UnitId equals ut.Id
        //                     join tx in db.TaxMasters.AsNoTracking() on hd.TaxId equals tx.Id
        //                     where bd.IsActive == "Y"
        //                     && ct.IsActive == "Y"
        //                     && ut.IsActive == "Y"
        //                     && tx.IsActive == "Y"
        //                     select new { hd, bd, ct, ut, tx }).AsQueryable();

        //        if (productId > 0)
        //            query = query.Where(a => a.hd.ProductId == productId);

        //        if (brandId > 0)
        //            query = query.Where(a => a.bd.Id == brandId);

        //        if (categoryId > 0)
        //            query = query.Where(a => a.ct.Id == categoryId);

        //        var lst = query.Select(a => new SupplierPaymentReportViewModel
        //        {
        //            ProductId = a.hd.ProductId,
        //            BrandDes = a.bd.BranchName,
        //            CategoryDes = a.ct.CategoryName,
        //            UnitDes = a.ut.UnitName,
        //            TaxDes = a.tx.TaxName,
        //            CessTax = a.hd.CessTax,
        //            Description = a.hd.Description,
        //            GenericName = a.hd.GenericName,
        //            ProductName = a.hd.ProductName,
        //            SalesPriceMRP = a.hd.SalesPriceMRP,
        //            RecorderQuantity = a.hd.RecorderQuantity,
        //            RackNo = a.hd.RackNo,
        //            HSNSACCode = a.hd.HSNSACCode,
        //            ItemType = a.hd.ItemType,
        //            ItemSkuCode = a.hd.ItemSkuCode
        //        }).OrderBy(a => a.ProductName).ToList();

        //        foreach (var i in lst)
        //        {
        //            i.ItemTypeDescription = System.Enum.GetName(typeof(IMS.Utilities.Enums.ItemType), (int)i.ItemType);
        //        }
        //        return lst;
        //    }
        //}
    }

    public partial class SupplierPaymentModel
    {
        public long Id { get; set; }
        public Nullable<int> PurchaseInvoiceId { get; set; }
        public int SuppilerId { get; set; }
        public decimal PaymentAmount { get; set; }
        public string PaymentNumber { get; set; }
        public string Description { get; set; }
        public System.DateTime PaymentDate { get; set; }

        public Nullable<int> IsDeleted { get; set; }
        public SelectList BindSupplierList { get; set; }
        public Int32 SupplierName { get; set; }
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