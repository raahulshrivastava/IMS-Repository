using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.Business
{
    class SalesManager
    {
        #region Sales
        public static List<SalesInvoice> GetAllDeatil()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.SalesInvoices.AsNoTracking().Where(a => a.IsDeleted == 0 && a.StoreId == UserSession.StoreId).OrderByDescending(a => a.Date).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SalesInvoice InsertUpdateSalesInvoice(SalesInvoiceModel inv)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    SalesInvoice hed = new SalesInvoice();
                    if (inv.Id > 0)
                    {
                        hed = db.SalesInvoices.Where(a => a.Id == inv.Id).FirstOrDefault();
                        hed.TotalCGST = inv.TotalCGST;
                        hed.TotalSGST = inv.TotalSGST;
                        hed.TotalIGST = inv.TotalIGST;
                        hed.TotalTaxAmount = inv.TotalTaxAmount;
                        hed.Discount = inv.Discount;
                        hed.TotalAmount = inv.ActualAmount;
                        hed.ExtraAmount = inv.ExtraCharge;
                        hed.FinalAmount = inv.FinalAmount;
                        hed.PaidAmount = inv.PaidAmount;
                        hed.Description = inv.Description;
                        hed.InvoiceType = inv.InvoiceType;
                        hed.IsPosted = 0;
                        hed.IsDeleted = 0;
                        hed.ModifiedBy = (int)UserSession.Id;
                        hed.ModifiedOn = DateTime.Now.Date;
                        db.Entry(hed).State = System.Data.Entity.EntityState.Modified;
                        inv.StatusId = 3;
                        inv.StatusMessage = "Invoice Updated Successfully.";
                        db.SaveChanges();
                    }
                    else
                    {
                        hed.Date = inv.Date;
                        hed.InvoiceNo = inv.InvoiceNo;
                        var incrementno = db.SalesInvoices.AsNoTracking().OrderByDescending(a => a.IncrementNo).Select(a => a.IncrementNo).FirstOrDefault();
                        var prefix = db.PrefixMasters.AsNoTracking().Where(a => a.PrefixName.ToUpper() == "SIINV").Select(a => new { a.PrefixName, a.StartingFrom }).FirstOrDefault();
                        hed.InvoiceNo = prefix.PrefixName + (int.Parse(prefix.StartingFrom) + incrementno + 1);
                        hed.IncrementNo = incrementno + 1;
                        hed.CustomerName = db.CustomerMasters.Where(a => a.Id == inv.CustomerId).Select(a => a.CustomerName).FirstOrDefault();

                        hed.TotalCGST = inv.TotalCGST;
                        hed.TotalSGST = inv.TotalSGST;
                        hed.TotalIGST = inv.TotalIGST;
                        hed.TotalTaxAmount = inv.TotalTaxAmount;
                        hed.Discount = inv.Discount;
                        hed.TotalAmount = inv.ActualAmount;
                        hed.ExtraAmount = inv.ExtraCharge;
                        hed.FinalAmount = inv.FinalAmount;

                        hed.PaidAmount = inv.PaidAmount;
                        hed.FinancialId = int.Parse(UserSession.FinYear);
                        hed.StoreId = UserSession.StoreId;
                        hed.CustomerId = (int)inv.CustomerId;
                        hed.Description = inv.Description;
                        hed.InvoiceType = inv.InvoiceType;
                        hed.IsPosted = 0;
                        hed.IsDeleted = 0;
                        hed.CreatedBy = (int)UserSession.Id;
                        hed.CreatedOn = DateTime.Now.Date;
                        db.SalesInvoices.Add(hed);
                        db.SaveChanges();
                        inv.StatusId = 1;
                        inv.StatusMessage = "Invoice Added Successfully.";
                    }


                    if (!string.IsNullOrEmpty(inv.hidData))
                    {
                        var det = db.SalesInvoiceDetails.Where(a => a.SalesInvInvoiceId == hed.Id).ToList();
                        db.SalesInvoiceDetails.RemoveRange(det);
                        db.SaveChanges();

                        InsertIntoSalesInvDetail(inv.hidData, hed.Id);
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertIntoSalesInvDetail(string inv, Int64 salesInvoiceId)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    string[] rows = inv.Split('$');
                    for (int r = 0; r < rows.Length; r++)
                    {
                        if (!string.IsNullOrEmpty(rows[r]))
                        {
                            string[] col = rows[r].Split('!');
                            SalesInvoiceDetail det = new SalesInvoiceDetail();
                            det.ProductId = int.Parse(col[1]);
                            det.Quantity = int.Parse(col[3]);
                            det.TotalAmount = decimal.Parse(col[4]);
                            det.Discount = decimal.Parse(col[5]);
                            det.TaxableAmount = decimal.Parse(col[6]);
                            det.CGSTAmount = decimal.Parse(col[7]);
                            det.SGSTAmount = decimal.Parse(col[8]);
                            det.IGSTAmount = decimal.Parse(col[9]);
                            det.GrossAmount = decimal.Parse(col[10]);
                            det.FreeQuantity = int.Parse(col[11]);
                            det.Price = decimal.Parse(col[14]);
                            det.MPR = decimal.Parse(col[15]);
                            det.TotalQauntity = int.Parse(col[12]);
                            if (Convert.ToString(col[19]) == "IGST")
                            {
                                det.IGSTPercentage = decimal.Parse(col[18]);
                                det.CGSTPercentage = 0;
                                det.SGSTPercent = 0;
                            }
                            if (Convert.ToString(col[19]) == "GST")
                            {
                                det.IGSTPercentage = 0;
                                det.CGSTPercentage = decimal.Parse(col[16]);
                                det.SGSTPercent = decimal.Parse(col[17]);
                            }

                            if (UserSession.StoreType == 0)
                            {
                                det.BatchNo = Convert.ToString(col[20]);
                                det.ExpiryDate = DateTime.Parse(col[21]);
                            }
                            else
                            {
                                det.BatchNo = "";
                                det.ExpiryDate = null;
                            }

                            det.SalesInvInvoiceId = salesInvoiceId;
                            db.SalesInvoiceDetails.Add(det);
                            db.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetSalesDetailsByProductId(Int64 productId)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var result = db.StockInDetailMasters.AsNoTracking().Where(a => a.ProductId == productId).Select(a => new { a.Quantity, a.BatchNo, a.ExpiryDate }).FirstOrDefault();
                    return (result != null ? (Convert.ToString(result.BatchNo) + "!" + Convert.ToString(result.ExpiryDate) + "!" + Convert.ToString(result.Quantity)) : "!!!");
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
                    var T = db.SalesInvoices.Where(a => a.Id == id).FirstOrDefault();
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
        public static SalesInvoiceModel GetSalesDetailById(Int64 id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    SalesInvoiceModel inv = new SalesInvoiceModel();
                    var salesInvoice = GetSalesInvoice(id);
                    inv = new SalesInvoiceModel()
                    {
                        Id = salesInvoice.Id,
                        Date = salesInvoice.Date,
                        InvoiceNo = salesInvoice.InvoiceNo,
                        TotalCGST = (decimal)salesInvoice.TotalCGST,
                        TotalSGST = (decimal)salesInvoice.TotalSGST,
                        TotalIGST = (decimal)salesInvoice.TotalIGST,
                        TotalTaxAmount = (decimal)salesInvoice.TotalTaxAmount,
                        Discount = (decimal)salesInvoice.Discount,
                        ActualAmount = (decimal)salesInvoice.TotalAmount,
                        ExtraCharge = (decimal)salesInvoice.ExtraAmount,
                        FinalAmount = (decimal)salesInvoice.FinalAmount,
                        PaidAmount = (decimal)salesInvoice.PaidAmount,
                        CustomerId = (int)salesInvoice.CustomerId,
                        Description = salesInvoice.Description,
                        InvoiceType = salesInvoice.InvoiceType,
                        IsPosted = salesInvoice.IsPosted.ToString(),
                    };

                    var countDet = db.SalesInvoiceDetails.AsNoTracking().Where(a => a.SalesInvInvoiceId == id).Count();
                    if (countDet > 0)
                    {
                        var det = GetSalesInvoiceDetailsById(id);
                        var _det = det.FirstOrDefault();

                        inv.GSTType = _det.IGSTAmount == 0 ? 2 : 1;
                        foreach (var i in det)
                        {
                            var productDetail = db.ProductMasterHeaders.AsNoTracking().Where(a => a.ProductId == i.ProductId).Select(a => new { a.ProductName, a.CategoryId, a.UnitId }).FirstOrDefault();
                            var unitName = db.UnitMasters.AsNoTracking().Where(a => a.Id == productDetail.UnitId).Select(a => a.UnitName).FirstOrDefault();

                            inv.hidData += productDetail.ProductName + "!";
                            inv.hidData += i.ProductId + "!";
                            inv.hidData += unitName + "!";
                            inv.hidData += i.Quantity + "!";
                            inv.hidData += i.TotalAmount + "!";
                            inv.hidData += i.Discount + "!";
                            inv.hidData += i.TaxableAmount + "!";
                            inv.hidData += i.CGSTAmount + "!";
                            inv.hidData += i.SGSTAmount + "!";
                            inv.hidData += i.IGSTAmount + "!";
                            inv.hidData += i.GrossAmount + "!";
                            inv.hidData += i.FreeQuantity + "!";
                            inv.hidData += i.TotalQauntity + "!";
                            inv.hidData += productDetail.CategoryId + "!";

                            inv.hidData += i.Price + "!";
                            inv.hidData += i.MPR + "!";
                            inv.hidData += i.CGSTPercentage + "!";
                            inv.hidData += i.SGSTPercent + "!";
                            inv.hidData += i.IGSTPercentage + "!";
                            inv.hidData += (i.IGSTAmount == 0 ? "GST" : "IGST") + "!";
                            inv.hidData += i.BatchNo + "!";
                            inv.hidData += i.ExpiryDate + "!";
                            inv.hidData += "$";
                        }
                    }


                    return inv;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SalesInvoice GetSalesInvoice(Int64 id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.SalesInvoices.AsNoTracking().Where(a => a.Id == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<SalesInvoiceDetail> GetSalesInvoiceDetailsById(Int64 id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.SalesInvoiceDetails.AsNoTracking().Where(a => a.SalesInvInvoiceId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Sales Return
        public static SelectList BindInvoiceNo(string selval = "")
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return new SelectList(db.SalesInvoices.AsNoTracking().Where(a => a.IsPosted.Value == 1).ToList(), "Id", "InvoiceNo");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SelectList BindReturnReason()
        {
            try
            {

                var description = from Utilities.Enums.ReturnReason n in System.Enum.GetValues(typeof(Utilities.Enums.ReturnReason))
                                  select new { ID = (int)n, Name = EnumHelper.GetEnumDescription(n) };
                var enumData = (from Utilities.Enums.ReturnReason e in System.Enum.GetValues(typeof(Utilities.Enums.ReturnReason))
                                select new
                                {
                                    Value = (int)e,
                                    Text = e.ToString()
                                }).ToList();
                List<SelectListItem> itemList = new List<SelectListItem>();

                foreach (var e in enumData)
                {
                    SelectListItem item = new SelectListItem();
                    item.Text = EnumHelper.GetEnumDescription((Utilities.Enums.ReturnReason)e.Value);
                    item.Value = item.Text;
                    itemList.Add(item);
                }
                return new SelectList(itemList, "Value", "Text");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static IEnumerable<SalesReturnModel> BindDataGrid()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var T = (from r in db.SalesInvoiceReturnHeaders.AsNoTracking()
                             join s in db.CustomerMasters.AsNoTracking() on (Int64)r.CustomerId equals s.Id
                             where r.IsDeleted == false
                             && s.IsActive == "Y"
                             select new SalesReturnModel
                             {
                                 SalesReturnHeaderId = r.SalesInvoiceReturnHeaderId,
                                 Date = r.Date,
                                 ReturnNo = r.ReturnNo,
                                 CustomerId = r.CustomerId,
                                 CustomerName = s.CustomerName,
                                 InvoiceNo = r.InvoiceNo,
                                 InvoiceDate = r.InvoiceDate,
                                 ReturnReason = r.ReturnReason
                             }).ToList();
                    return T;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetSalesInvDetail(Int64 invId)
        {
            try
            {
                using (var db = new IMSContext())
                {

                    var purchase = (from det in db.SalesInvoiceDetails.AsNoTracking()
                                    join p in db.ProductMasterHeaders.AsNoTracking() on det.ProductId equals p.ProductId
                                    where det.Id == invId
                                    select new
                                    {
                                        p.ProductName,
                                        det.BatchNo,
                                        det.ExpiryDate,
                                        det.Quantity,
                                        det.FreeQuantity,
                                        det.TotalQauntity,
                                        p.ProductId,
                                        det.Id
                                    }).ToList();

                    string detail = string.Empty;
                    foreach (var i in purchase)
                    {
                        detail += i.ProductName + "!";
                        detail += i.BatchNo + "!";
                        detail += i.ExpiryDate + "!";
                        detail += i.Quantity + "!";
                        detail += i.FreeQuantity + "!";
                        detail += i.TotalQauntity + "!";
                        detail += i.ProductId + "!";
                        detail += i.Id + "!";
                        detail += "" + "!";
                        detail += "$";
                    }

                    return detail;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int GetTotalQuantity(Int64 detailId)
        {
            try
            {
                using (var db = new IMSContext())
                {

                    var totalQty = (from det in db.SalesInvoiceDetails.AsNoTracking() where det.Id == detailId select det.TotalQauntity).FirstOrDefault();
                    return Convert.ToInt32(totalQty);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SalesReturnModel InsertUpdateSalesReturn(SalesReturnModel ret)
        {

            try
            {
                using (var db = new IMSContext())
                {
                    Int64 hedId = 0;
                   
                    var invNo = db.SalesInvoices.Where(a => a.Id == ret.InvoiceId).Select(a => a.InvoiceNo).FirstOrDefault();
                    if (ret.SalesReturnHeaderId > 0)
                    {
                        var hed = GetSalesInvoiceReturnHeaderById(ret.SalesReturnHeaderId);
                        hed.Description = ret.Description;
                        hed.InvoiceNo = invNo;
                        hed.ModifiedBy = (Int32)UserSession.Id;
                        hed.ModifiedOn = DateTime.Now.Date;
                        hed.ReturnReason = ret.ReturnReason;
                        hed.CustomerId = (int)ret.CustomerId;
                        hed.InvoiceDate = ret.InvoiceDate;
                        db.Entry(hed).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        hedId = ret.SalesReturnHeaderId;
                        ret.Status = "Record updated successfully.";
                        ret.StatusId = (int)Enums.Message.Success;
                    }
                    else
                    {
                        SalesInvoiceReturnHeader hed = new SalesInvoiceReturnHeader();
                        hed.Date = ret.Date;
                        hed.Description = ret.Description;
                        hed.InvoiceDate = ret.InvoiceDate;
                        hed.InvoiceNo = invNo;
                        hed.ReturnReason = ret.ReturnReason;
                        hed.CustomerId = (int)ret.CustomerId;
                        hed.CreatedBy = (int)UserSession.Id;
                        hed.CreatedOn = DateTime.Now.Date;
                        var incrementno = db.SalesInvoiceReturnHeaders.AsNoTracking().OrderByDescending(a => a.IncrementedNo).Select(a => a.IncrementedNo).FirstOrDefault();
                        hed.IncrementedNo = (Int32)(incrementno ?? 0 + 1);
                        hed.IsDeleted = false;
                        var enmPrefixName = Enum.GetName(typeof(Enums.Prefix), Enums.Prefix.SR);
                        var prefix = db.PrefixMasters.AsNoTracking().Where(a => a.PrefixName == enmPrefixName).Select(a => new { a.StartingFrom, a.PrefixName }).FirstOrDefault();
                        var returnNonp = int.Parse(prefix.StartingFrom) + incrementno + 1;
                        hed.ReturnNo = prefix.PrefixName + "-" + returnNonp.ToString();
                        db.SalesInvoiceReturnHeaders.Add(hed);
                        db.SaveChanges();
                        hedId = hed.SalesInvoiceReturnHeaderId;
                        ret.Status = "Record Saved Successfully.";
                        ret.SalesReturnHeaderId = (int)hedId;
                        ret.StatusId = (int)Enums.Message.Success;
                    }

                    var lstDetail = GetSalesReturnDetails(ret.SalesReturnHeaderId);
                    foreach (var i in lstDetail)
                    {
                        db.Entry(i).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                    }

                    if (!string.IsNullOrEmpty(ret.hidTempDetail))
                    {
                        var rows = ret.hidTempDetail.Split('$');
                        for (int c = 0; c < rows.Length; c++)
                        {
                            if (!string.IsNullOrEmpty(rows[c]))
                            {
                                var col = rows[c].Split('!');
                                SalesInvoiceReturnDetail det = new SalesInvoiceReturnDetail();
                                det.BatchNo = (col[1] == null || col[1] == "") ? "--" : col[1];

                                if (!string.IsNullOrEmpty(col[2])) { det.ExpiryDate = (DateTime)DateTime.Parse(col[2]); };

                                det.FreeQuantity = int.Parse(col[4]);
                                det.ProductId = Int32.Parse(col[6]);
                                det.SalesRerutnHeaderId = (int)hedId;
                                det.Quantity = int.Parse(col[3]);
                                det.ReturnQuantity = int.Parse(col[8]);
                                det.TotalQuantity = int.Parse(col[5]);
                                db.SalesInvoiceReturnDetails.Add(det);
                                db.SaveChanges();
                            }

                        }
                    }
                }




            }
            catch (Exception ex)
            {
                ret.Status = Convert.ToString(ex.Message);
                ret.StatusId = (int)Enums.Message.Error;
            }
            return ret;
        }
        public static List<SalesInvoiceReturnDetail> GetSalesReturnDetails(Int64 id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.SalesInvoiceReturnDetails.Where(a => a.SalesRerutnHeaderId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SalesInvoiceReturnHeader GetSalesInvoiceReturnHeaderById(Int64 id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.SalesInvoiceReturnHeaders.Where(a => a.SalesInvoiceReturnHeaderId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SalesReturnModel GetSalesReturnDetail(Int64 id)
        {
            using (var db = new IMSContext())
            {
                var headerDetail = (from hed in db.SalesInvoiceReturnHeaders.AsNoTracking()
                                    join p in db.SalesInvoices.AsNoTracking() on hed.InvoiceNo equals p.InvoiceNo
                                    where hed.SalesInvoiceReturnHeaderId == id
                                    select new SalesReturnModel
                                    {
                                        SalesReturnHeaderId = hed.SalesInvoiceReturnHeaderId,
                                        Date = hed.Date,
                                        Description = hed.Description,
                                        InvoiceDate = hed.InvoiceDate,
                                        InvoiceId = (Int32)p.Id,
                                        InvoiceNo = hed.InvoiceNo,
                                        ReturnNo = hed.ReturnNo,
                                        ReturnReason = hed.ReturnReason,
                                        SalesInvoiceId = p.Id,
                                        CustomerId = hed.CustomerId
                                    }).FirstOrDefault();

                var d = (from det in db.SalesInvoiceReturnDetails.AsNoTracking() where det.SalesRerutnHeaderId == id select det).ToList();

                string detail = "";
                foreach (var i in d)
                {
                    var productName = db.ProductMasterHeaders.AsNoTracking().Where(a => a.ProductId == i.ProductId).Select(a => a.ProductName).FirstOrDefault();
                    detail += productName + "!";
                    detail += i.BatchNo + "!";
                    if (i.ExpiryDate != null) { detail += i.ExpiryDate.Value.ToString("dd-MM-yyyy") + "!"; }
                    else { detail += "" + "!"; }

                    detail += i.Quantity + "!";
                    detail += i.FreeQuantity + "!";
                    detail += i.TotalQuantity + "!";
                    detail += i.ProductId + "!";
                    detail += db.SalesInvoiceDetails.AsNoTracking().Where(a => a.SalesInvInvoiceId == headerDetail.SalesInvoiceId).Select(a => a.SalesInvInvoiceId).FirstOrDefault() + "!";
                    detail += i.ReturnQuantity + "!";
                    detail += "$";
                }

                if (headerDetail == null)
                    headerDetail = new SalesReturnModel();

                headerDetail.hidTempDetail = detail;

                return headerDetail;
            }
        }
        public static void InitializeAddEdit(SalesReturnModel ret)
        {
            try
            {
                ret.CustomerList = CommonClass.GetCustomerList();
                ret.InvoiceList = BindInvoiceNo();
                ret.ReturnReasonList = BindReturnReason();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static bool DeleteRecord(Int64 id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var T = db.SalesInvoiceReturnHeaders.Where(a => a.SalesInvoiceReturnHeaderId == id).FirstOrDefault();
                    T.IsDeleted = true;
                    T.ModifiedBy = (int)UserSession.Id;
                    T.ModifiedOn = DateTime.Now.Date;
                    db.Entry(T).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }

    public class SalesInvoiceModel
    {
        public SalesInvoiceModel()
        {
            CustomerList = new SelectList(Enumerable.Empty<SelectList>());
            InvoiceTypeList = new SelectList(Enumerable.Empty<SelectList>());
            CategoryList = new SelectList(Enumerable.Empty<SelectList>());
            ProductList = new SelectList(Enumerable.Empty<SelectList>());
            ProductTaxType = new SelectList(Enumerable.Empty<SelectList>());
            BatchNoList = new SelectList(Enumerable.Empty<SelectList>());
        }

        public Int64 Id { get; set; }
        public Int64 DetailId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Int64 CustomerId { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceType { get; set; }
        public string hidData { get; set; }
        public string IsPosted { get; set; }

        public SelectList CustomerList { get; set; }
        public SelectList InvoiceTypeList { get; set; }

        public decimal TotalCGST { get; set; }
        public decimal TotalSGST { get; set; }
        public decimal TotalIGST { get; set; }
        public decimal Discount { get; set; }
        public decimal ActualAmount { get; set; }
        public decimal TotalTaxAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal ExtraCharge { get; set; }
        public decimal FinalAmount { get; set; }
        public decimal PaidAmount { get; set; }

        public decimal CGSTPercentage { get; set; }
        public decimal SGSTPercentage { get; set; }
        public decimal IGSTPercentage { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal IGSTAmount { get; set; }
        public SelectList ProductTaxType { get; set; }
        public string ProductTax { get; set; }

        public string CategoryName { get; set; }
        public SelectList CategoryList { get; set; }
        public string ProductName { get; set; }
        public SelectList ProductList { get; set; }
        public string Status { get; set; }
        public string StatusMessage { get; set; }
        public int GSTType { get; set; }

        public bool ShowHideBatchExpiry { get; set; }
        public string AvailableQuantities { get; set; }
        public string Unit { get; set; }
        public string BatchNo { get; set; }
        public SelectList BatchNoList { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string HSNCode { get; set; }
        public string SKUCode { get; set; }
        public decimal MRP { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalAmt { get; set; }
        public decimal AddProductDiscount { get; set; }
        public decimal GrossAmt { get; set; }
        public int FreeQty { get; set; }
        public int TotalQty { get; set; }

        public int StatusId { get; set; }
    }

    public class SalesReturnModel
    {
        public int SalesReturnHeaderId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ReturnNo { get; set; }
        public Nullable<long> CustomerId { get; set; }
        public string CustomerName { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string ReturnReason { get; set; }
        public Int64 SalesInvoiceId { get; set; }
        public string Description { get; set; }

        public SelectList CustomerList { get; set; }
        public SelectList InvoiceList { get; set; }
        public SelectList ReturnReasonList { get; set; }

        public string hidTempDetail { get; set; }

        public string Status { get; set; }
        public int StatusId { get; set; }
        public bool ShowHideBatchExpiry { get; set; }
    }


}