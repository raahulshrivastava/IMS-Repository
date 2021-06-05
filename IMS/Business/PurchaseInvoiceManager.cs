using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web.Mvc;

using IMS.Utilities;
using IMS.DataContext;
using IMS.Models.PurchaseReturn;
using System.Data.SqlClient;

namespace IMS.Business
{
    public class PurchaseInvoiceManager
    {
        #region Purchase Invoice
        public static string GetProductDetailById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    string det = "";
                    var product = db.ProductMasterHeaders.AsNoTracking().Where(a => a.ProductId == id).FirstOrDefault();
                    var skucode = Convert.ToString(product.ItemSkuCode);
                    var hsncode = Convert.ToString(product.HSNSACCode);
                    var unit = db.UnitMasters.AsNoTracking().Where(a => a.Id == product.UnitId).Select(a => a.UnitName).FirstOrDefault();
                    var tax = db.TaxMasters.AsNoTracking().Where(a => a.Id == product.TaxId).Select(a => new { a.CGSTValue, a.SGSTValue }).FirstOrDefault();
                    var cgstval = tax.CGSTValue;
                    var sgstval = tax.SGSTValue;
                    var totalproduct = cgstval + sgstval;
                    det = Convert.ToString(unit);
                    det += "!" + Convert.ToString(hsncode);
                    det += "!" + Convert.ToString(skucode);
                    det += "!" + Convert.ToString(cgstval);
                    det += "!" + Convert.ToString(sgstval);
                    det += "!" + Convert.ToString(totalproduct);
                    return det;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static PurchaserInvoiceHeader InsertIntoPurchaseInvHeader(PurchaseInvModel inv)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    PurchaserInvoiceHeader hed = new PurchaserInvoiceHeader();
                    hed.Date = (DateTime)inv.Date;
                    hed.Description = inv.Description;
                    hed.Discount = inv.DiscountHeader;
                    hed.ExtraAmount = inv.ExtraAmount;
                    hed.FinalAmount = inv.FinalAmount;
                    hed.FinalDiscount = inv.FinalDiscount;
                    hed.FinancialId = int.Parse(UserSession.FinYear);
                    Int32 incrementno = db.PurchaserInvoiceHeaders.AsNoTracking().OrderByDescending(a => a.IncrementNo).Select(a => a.IncrementNo).FirstOrDefault();
                    var prefix = db.PrefixMasters.AsNoTracking().Where(a => a.PrefixName.ToUpper() == "PIINV").Select(a => new { a.PrefixName, a.StartingFrom }).FirstOrDefault();
                    hed.InvoiceNo = prefix.PrefixName + (int.Parse(prefix.StartingFrom) + incrementno + 1);
                    hed.IncrementNo = incrementno + 1;
                    hed.PaidAmount = inv.PaidAmount;
                    hed.StoreId = UserSession.StoreId;
                    hed.SupplierBillDate = (DateTime)inv.SupplierBillDate;
                    hed.SupplierBillNo = inv.SupplierBillNo;
                    hed.SupplierID = inv.SupplierName;
                    hed.TotalAmount = inv.TotalAmountHeader;
                    hed.TotalCGST = inv.TotalCGST;
                    hed.TotalSGST = inv.TotalSGST;
                    hed.TotalIGST = inv.TotalIGST;
                    hed.TotalTaxAmount = inv.TotalTaxAmount;
                    hed.IsDeleted = 0;
                    hed.IsPosted = 0;
                    hed.InvoiceType = inv.InvoiceType;
                    hed.CreatedBy = (int)UserSession.Id;
                    hed.CreatedOn = DateTime.Now.Date;
                    db.PurchaserInvoiceHeaders.Add(hed);
                    db.SaveChanges();

                    inv.PurchaserInvHeaderId = hed.PurchaseInvHeadId;
                    if (!string.IsNullOrEmpty(inv.hidForward))
                    {
                        InsertIntoPurchaseInvDetail(inv);
                    }
                    return hed;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertIntoPurchaseInvDetail(PurchaseInvModel inv)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    string[] rows = inv.hidForward.Split('$');
                    for (int r = 0; r < rows.Length; r++)
                    {
                        if (!string.IsNullOrEmpty(rows[r]))
                        {
                            string[] col = rows[r].Split('!');
                            PurchaseInvoiceDetail det = new PurchaseInvoiceDetail();

                            det.PurchaserInvHeaderId = inv.PurchaserInvHeaderId;
                            det.ProductId = int.Parse(col[1]);
                            det.ChallanNo = col[14];
                            det.Quantity = int.Parse(col[12]);
                            det.Price = decimal.Parse(col[15]);
                            det.MPR = decimal.Parse(col[16]);
                            det.TotalAmount = decimal.Parse(col[4]);
                            det.Discount = decimal.Parse(col[5]); 
                            det.TaxableAmount = decimal.Parse(col[6]);
                            det.IGSTAmount = decimal.Parse(col[9]);
                            det.CGSTAmount = decimal.Parse(col[7]);
                            det.SGSTAmount = decimal.Parse(col[8]);

                            if (Convert.ToString(col[20]) == "IGST")
                            {
                                det.IGSTPercentage = decimal.Parse(col[19]);
                                det.CGSTPercentage = 0;
                                det.SGSTPercent = 0;
                            }
                            if (Convert.ToString(col[20]) == "GST")
                            {
                                det.IGSTPercentage = 0;
                                det.CGSTPercentage = decimal.Parse(col[17]);
                                det.SGSTPercent = decimal.Parse(col[18]);
                            }


                            det.GrossAmount = decimal.Parse(col[10]);
                            det.FreeQuantity = int.Parse(col[11]);
                            det.TotalQauntity = int.Parse(col[12]);

                            if (UserSession.StoreType == 0)
                            {
                                det.BatchNo = Convert.ToString(col[21]);
                                det.ExpiryDate = DateTime.Parse(col[22]);
                            }
                            else
                            {
                                det.BatchNo = "";
                                det.ExpiryDate = null;
                            }
                            db.PurchaseInvoiceDetails.Add(det);
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
        public static List<PurchaserInvoiceHeader> GetAllDeatil()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.PurchaserInvoiceHeaders.AsNoTracking().Where(a => a.IsDeleted == 0 && a.StoreId == UserSession.StoreId).OrderByDescending(a => a.Date).ToList();
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
                    var T = db.PurchaserInvoiceHeaders.Where(a => a.PurchaseInvHeadId == id).FirstOrDefault();
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
        public static PurchaseInvModel GetInvoiceDetailById(Int64 id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    PurchaseInvModel inv = new PurchaseInvModel();
                    var hed = GetPurchaserInvoiceHeaderById(id);
                    inv = new PurchaseInvModel()
                    {
                        Description = hed.Description,
                        DiscountHeader = hed.Discount,
                        ExtraAmount = hed.ExtraAmount,
                        FinalAmount = hed.FinalAmount,
                        FinalDiscount = hed.FinalDiscount,
                        InvoiceNo = hed.InvoiceNo,
                        InvoiceType = hed.InvoiceType,
                        IsPosted = hed.IsPosted.ToString(),
                        PaidAmount = hed.PaidAmount,
                        PurchaserInvHeaderId = hed.PurchaseInvHeadId,
                        SupplierBillDate = hed.SupplierBillDate,
                        SupplierBillNo = hed.SupplierBillNo,
                        SupplierName = (int)hed.SupplierID,
                        TotalAmountHeader = hed.TotalAmount,
                        TotalCGST = hed.TotalCGST,
                        TotalIGST = hed.TotalIGST,
                        TotalSGST = hed.TotalSGST,
                        TotalTaxAmount = hed.TotalTaxAmount,
                        Date = hed.Date
                    };

                    var countDet = db.PurchaseInvoiceDetails.AsNoTracking().Where(a => a.PurchaserInvHeaderId == id).Count();
                    if (countDet > 0)
                    {
                        var det = GetPurchaseInvoiceDetailById(id);
                        var _det = det.FirstOrDefault();

                        inv.GSTType = _det.IGSTAmount == 0 ? 2 : 1;
                        foreach (var i in det)
                        {
                            var product = ProductMasterManager.GetValuesHeaderById(i.ProductId);
                            var unit = UnitMasterManager.GetDataById(product.UnitId);

                            inv.hidForward += product.ProductName + "!";
                            inv.hidForward += i.ProductId + "!";
                            inv.hidForward += unit.UnitName + "!";
                            inv.hidForward += i.Quantity + "!";
                            inv.hidForward += i.TotalAmount + "!";
                            inv.hidForward += i.Discount + "!";
                            inv.hidForward += i.TaxableAmount + "!";
                            inv.hidForward += i.CGSTAmount + "!";
                            inv.hidForward += i.SGSTAmount + "!";
                            inv.hidForward += i.IGSTAmount + "!";
                            inv.hidForward += i.GrossAmount + "!";
                            inv.hidForward += i.FreeQuantity + "!";
                            inv.hidForward += i.TotalQauntity + "!";
                            inv.hidForward += product.CategoryId + "!";
                            inv.hidForward += i.ChallanNo + "!";
                            inv.hidForward += i.Price + "!";
                            inv.hidForward += i.MPR + "!";
                            inv.hidForward += i.CGSTPercentage + "!";
                            inv.hidForward += i.SGSTPercent + "!";
                            inv.hidForward += i.IGSTPercentage + "!";
                            inv.hidForward += (i.IGSTAmount == 0 ? "GST" : "IGST") + "!";
                            inv.hidForward += i.BatchNo + "!";
                            inv.hidForward += i.ExpiryDate + "!";
                            inv.hidForward += "$";
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
        public static PurchaserInvoiceHeader GetPurchaserInvoiceHeaderById(Int64 id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.PurchaserInvoiceHeaders.AsNoTracking().Where(a => a.PurchaseInvHeadId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<PurchaseInvoiceDetail> GetPurchaseInvoiceDetailById(Int64 id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.PurchaseInvoiceDetails.AsNoTracking().Where(a => a.PurchaserInvHeaderId == id).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static PurchaseInvModel UpdateInvoice(PurchaseInvModel inv)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var e = db.PurchaserInvoiceHeaders.Where(a => a.PurchaseInvHeadId == inv.PurchaserInvHeaderId).FirstOrDefault();
                    e.TotalCGST = inv.TotalCGST;
                    e.TotalIGST = inv.TotalIGST;
                    e.TotalSGST = inv.TotalSGST;
                    e.TotalTaxAmount = inv.TotalTaxAmount;
                    e.TotalAmount = inv.TotalAmountHeader;
                    e.FinalAmount = inv.FinalAmount;
                    e.ExtraAmount = inv.ExtraAmount;
                    e.Discount = inv.DiscountHeader;
                    e.PaidAmount = inv.PaidAmount;
                    e.Description = inv.Description;
                    e.ModifiedBy = (int)UserSession.Id;
                    e.ModifiedOn = DateTime.Now.Date;
                    db.Entry(e).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    var countDet = db.PurchaseInvoiceDetails.Where(a => a.PurchaserInvHeaderId == inv.PurchaserInvHeaderId).Count();
                    if (countDet > 0)
                    {
                        var det = db.PurchaseInvoiceDetails.Where(a => a.PurchaserInvHeaderId == inv.PurchaserInvHeaderId).ToList();
                        foreach (var i in det)
                        {
                            db.Entry(i).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();
                        }
                    }

                    if (!string.IsNullOrEmpty(inv.hidForward))
                    {
                        InsertIntoPurchaseInvDetail(inv);
                    }

                    return inv;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void BindDropDown(PurchaseInvModel inv)
        {
            try
            {
                inv.BindProduct = CommonClass.GetProductList();
                inv.BindSupplierList = CommonClass.GetSupplierList();
                inv.CategoryDdl = CommonClass.GetCategoryList();
                inv.InvoiceTypeList = CommonClass.BindInvoiceType();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Purchase Return
        public static SelectList BindInvoiceNo(string selval = "")
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return new SelectList(db.PurchaserInvoiceHeaders.AsNoTracking().Where(a => a.IsPosted.Value == 1).ToList(), "PurchaseInvHeadId", "InvoiceNo");
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

        public static IEnumerable<PurchaseReturnModel> BindDataGrid()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var T = (from r in db.PurchaseReturnHeaders.AsNoTracking()
                             join s in db.SupplierMasters.AsNoTracking() on r.SupplierId equals s.Id
                             where r.IsDeleted == 0
                             && s.IsActive == "Y"
                             select new PurchaseReturnModel
                             {
                                 PurchaseReturnHeaderId = r.PurchaseReturnHeaderId,
                                 Date = r.Date,
                                 ReturnNo = r.ReturnNo,
                                 SupplierId = r.SupplierId,
                                 SupplierName = s.SupplierName,
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

        //public static string GetPurchaseInvDetail(Int64 invId)
        //{
        //    try
        //    {
        //        using (var db = new IMSContext())
        //        {

        //            var purchase = (from det in db.PurchaseInvoiceDetails.AsNoTracking()
        //                            join p in db.ProductMasterHeaders.AsNoTracking() on det.ProductId equals p.ProductId
        //                            where det.PurchaserInvHeaderId == invId
        //                            select new
        //                            {
        //                                p.ProductName,
        //                                det.BatchNo,
        //                                det.ExpiryDate,
        //                                det.Quantity,
        //                                det.FreeQuantity,
        //                                det.TotalQauntity,
        //                                p.ProductId,
        //                                det.PurchaserInvDetId
        //                            }).ToList();

        //            string detail = string.Empty;
        //            foreach (var i in purchase)
        //            {
        //                detail += i.ProductName + "!";
        //                detail += i.BatchNo + "!";
        //                detail += i.ExpiryDate + "!";
        //                detail += i.Quantity + "!";
        //                detail += i.FreeQuantity + "!";
        //                detail += i.TotalQauntity + "!";
        //                detail += i.ProductId + "!";
        //                detail += i.PurchaserInvDetId + "!";
        //                detail += "$";
        //            }

        //            return detail;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public static string GetPurchaseInvDetail(Int64 invId)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    string query = $" select PID.ProductId, PH.ProductName, PID.Quantity, PID.FreeQuantity, PID.TotalQauntity, PID.BatchNo, PID.ExpiryDate, PID.PurchaserInvDetId, ISNULL(SUM(PRD.ReturnQuantity),0) as AlreadyReturn from PurchaserInvoiceHeader PIH inner join PurchaseInvoiceDetail PID on PIH.PurchaseInvHeadId = PID.PurchaserInvHeaderId inner join ProductMasterHeader PH on PH.ProductId = PID.ProductId left join PurchaseReturnHeader PRH on PRH.InvoiceNo = PIH.InvoiceNo left join PurchaseInvReturnDetail PRD on PRH.PurchaseReturnHeaderId = PRD.PurchaseRerutnHeaderId and PRD.ProductId = PH.ProductId where  PIH.PurchaseInvHeadId = {invId} group by PID.ProductId, PH.ProductName, PID.Quantity, PID.FreeQuantity, PID.TotalQauntity, PID.BatchNo, PID.ExpiryDate, PID.PurchaserInvDetId ";
                    var dt = DbUtility.GetDataTable(new SqlCommand() { CommandText = query });
                    string detail = string.Empty;
                    foreach (DataRow dr in dt.Rows)
                    {
                        detail += Convert.ToString(dr["ProductName"]) + "!";
                        detail += Convert.ToString(dr["BatchNo"]) + "!";
                        detail += Convert.ToString(dr["ExpiryDate"]) + "!";
                        detail += Convert.ToDecimal(dr["Quantity"]) + "!";
                        detail += Convert.ToDecimal(dr["FreeQuantity"]) + "!";
                        detail += Convert.ToDecimal(dr["TotalQauntity"]) + "!";
                        detail += Convert.ToInt32(dr["ProductId"]) + "!";
                        detail += Convert.ToInt32(dr["PurchaserInvDetId"]) + "!";
                        detail += Convert.ToDecimal(dr["AlreadyReturn"]) + "!";
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

                    var totalQty = (int)(from det in db.PurchaseInvoiceDetails.AsNoTracking() where det.PurchaserInvDetId == detailId select det.TotalQauntity).FirstOrDefault();
                    return totalQty;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PurchaseReturnModel InsertUpdatePurchaseReturn(PurchaseReturnModel ret)
        {

            try
            {
                using (var db = new IMSContext())
                {
                    Int64 hedId = 0;

                    var invNo = db.PurchaserInvoiceHeaders.Where(a => a.PurchaseInvHeadId == ret.InvoiceId).Select(a => a.InvoiceNo).FirstOrDefault();
                    if (ret.PurchaseReturnHeaderId > 0)
                    {
                        PurchaseReturnHeader hed = db.PurchaseReturnHeaders.AsNoTracking().Where(a => a.PurchaseReturnHeaderId == ret.PurchaseReturnHeaderId).FirstOrDefault();
                        hed.Description = ret.Description;
                        hed.InvoiceNo = invNo;
                        hed.ModifiedBy = (Int32)UserSession.Id;
                        hed.ModifiedOn = DateTime.Now.Date;
                        hed.ReturnReason = ret.ReturnReason;
                        hed.SupplierId = ret.SupplierId;
                        hed.InvoiceDate = ret.InvoiceDate;
                        db.Entry(hed).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        hedId = ret.PurchaseReturnHeaderId;
                        ret.Status = "Record updated successfully.";
                        ret.StatusId = (int)Enums.Message.Success;
                    }
                    else
                    {
                        PurchaseReturnHeader hed = new PurchaseReturnHeader();
                        hed.Date = ret.Date;
                        hed.Description = ret.Description;
                        hed.InvoiceDate = ret.InvoiceDate;
                        hed.InvoiceNo = invNo;
                        hed.ReturnReason = ret.ReturnReason;
                        hed.SupplierId = ret.SupplierId;
                        hed.CreatedBy = (int)UserSession.Id;
                        hed.CreatedOn = DateTime.Now.Date;
                        Int64 incrementno = db.PurchaseReturnHeaders.AsNoTracking().OrderByDescending(a => a.IncrementedNo).Select(a => a.IncrementedNo).FirstOrDefault();
                        hed.IncrementedNo = (Int32)(incrementno + 1);
                        hed.IsDeleted = 0;
                        var enmPrefixName = Enum.GetName(typeof(Enums.Prefix), Enums.Prefix.PR);
                        var prefix = db.PrefixMasters.AsNoTracking().Where(a => a.PrefixName == enmPrefixName).Select(a => new { a.StartingFrom, a.PrefixName }).FirstOrDefault();
                        var returnNonp = int.Parse(prefix.StartingFrom) + incrementno + 1;
                        hed.ReturnNo = prefix.PrefixName + "-" + returnNonp.ToString();
                        db.PurchaseReturnHeaders.Add(hed);
                        db.SaveChanges();
                        hedId = hed.PurchaseReturnHeaderId;
                        ret.Status = "Record Saved Successfully.";
                        ret.StatusId = (int)Enums.Message.Success;
                    }

                    var lstDetail = db.PurchaseInvReturnDetails.Where(a => a.PurchaseRerutnHeaderId == ret.PurchaseReturnHeaderId).ToList();
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
                                PurchaseInvReturnDetail det = new PurchaseInvReturnDetail();
                                det.BatchNo = (col[1] == null || col[1] == "") ? "--" : col[1];

                                if (!string.IsNullOrEmpty(col[2])) { det.ExpiryDate = (DateTime)DateTime.Parse(col[2]); };

                                det.FreeQuantity = int.Parse(col[4]);
                                det.ProductId = Int64.Parse(col[6]);
                                det.PurchaseRerutnHeaderId = hedId;
                                det.Quantity = int.Parse(col[3]);
                                det.ReturnQuantity = int.Parse(col[8]);
                                det.TotalQuantity = int.Parse(col[5]);
                                db.PurchaseInvReturnDetails.Add(det);
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
        public static List<PurchaseReturnList> GetPurchaseReturnDetail(int id)
        {
            using (var db = new IMSContext())
            {
                var data = (from d in db.PurchaseInvReturnDetails
                            join p in db.ProductMasterHeaders on d.ProductId equals p.ProductId
                            where d.Id == id
                            select new PurchaseReturnList()
                            {
                                Product = p.ProductName,
                                Quantity = d.Quantity ?? 0,
                                FreeQty = d.FreeQuantity ?? 0,
                                ReturnQty = d.ReturnQuantity ?? 0,
                                TotalQty = d.TotalQuantity ?? 0
                            }).ToList();
                return data;
            }
        }

        public static PurchaseReturnHeader GetPurchaseReturnById(int id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.PurchaseReturnHeaders.Where(a => a.PurchaseReturnHeaderId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static PurchaseReturnModel GetPurchaseReturnDetail(Int64 id)
        {
            using (var db = new IMSContext())
            {
                var headerDetail = (from hed in db.PurchaseReturnHeaders.AsNoTracking()
                                    join p in db.PurchaserInvoiceHeaders.AsNoTracking() on hed.InvoiceNo equals p.InvoiceNo
                                    where hed.PurchaseReturnHeaderId == id
                                    select new PurchaseReturnModel
                                    {
                                        PurchaseReturnHeaderId = hed.PurchaseReturnHeaderId,
                                        Date = hed.Date,
                                        Description = hed.Description,
                                        InvoiceDate = hed.InvoiceDate,
                                        InvoiceId = (Int32)p.PurchaseInvHeadId,
                                        InvoiceNo = hed.InvoiceNo,
                                        ReturnNo = hed.ReturnNo,
                                        ReturnReason = hed.ReturnReason,
                                        PurchaseInvoiceId = p.PurchaseInvHeadId,
                                        SupplierId = hed.SupplierId
                                    }).FirstOrDefault();

                var d = (from det in db.PurchaseInvReturnDetails.AsNoTracking() where det.PurchaseRerutnHeaderId == id select det).ToList();

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
                    detail += db.PurchaseInvoiceDetails.AsNoTracking().Where(a => a.PurchaserInvHeaderId == headerDetail.PurchaseInvoiceId).Select(a => a.PurchaserInvDetId).FirstOrDefault() + "!";
                    detail += i.ReturnQuantity + "!";
                    detail += "$";
                }

                headerDetail.hidTempDetail = detail;

                return headerDetail;
            }
        }

        public static void InitializeAddEdit(PurchaseReturnModel ret)
        {
            try
            {
                ret.SupplierList = CommonClass.GetSupplierList();
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
                    var T = db.PurchaseReturnHeaders.Where(a => a.PurchaseReturnHeaderId == id).FirstOrDefault();
                    T.IsDeleted = 1;
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

    public class PurchaseInvModel
    {
        public Int64 PurchaserInvDetId { get; set; }
        public Int64 PurchaserInvHeaderId { get; set; }
        public Int32 ProductId { get; set; }
        public SelectList BindProduct { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
        public SelectList CategoryDdl { get; set; }
        public string Unit { get; set; }
        public string ChallanNo { get; set; }
        public string BatchNo { get; set; }
        public System.DateTime? ExpiryDate { get; set; }
        public string HSNCode { get; set; }
        public Int32? Quantity { get; set; }
        public decimal? Price { get; set; }
        public decimal? MPR { get; set; }
        public string SKUCode { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? TaxableAmount { get; set; }
        public decimal? IGSTAmount { get; set; }
        public decimal? CGSTAmount { get; set; }
        public decimal? SGSTAmount { get; set; }
        public decimal? IGSTPercentage { get; set; }
        public decimal? CGSTPercentage { get; set; }
        public decimal? SGSTPercent { get; set; }
        public decimal? GrossAmount { get; set; }
        public Int32? FreeQuantity { get; set; }
        public Int32? TotalQauntity { get; set; }
        public string Description { get; set; }
        public int GSTType { get; set; }


        public System.DateTime? Date { get; set; }
        public System.DateTime? SupplierBillDate { get; set; }
        public Int32 SupplierName { get; set; }
        public SelectList BindSupplierList { get; set; }
        public string SupplierBillNo { get; set; }
        public string InvoiceNo { get; set; }

        public decimal? TotalCGST { get; set; }
        public decimal? TotalSGST { get; set; }
        public decimal? TotalIGST { get; set; }
        public decimal? TotalTaxAmount { get; set; }
        public decimal? DiscountHeader { get; set; }
        public decimal? TotalAmountHeader { get; set; }
        public decimal? ExtraAmount { get; set; }
        public decimal? FinalAmount { get; set; }
        public decimal? FinalDiscount { get; set; }
        public decimal? PaidAmount { get; set; }

        public string hidForward { get; set; }

        public bool ShowHideBatchExpiry { get; set; }

        public decimal CgstProdcut { get; set; }
        public decimal SgstProdcut { get; set; }
        public decimal TotalSumProdcut { get; set; }
        public string InvoiceType { get; set; }
        public SelectList InvoiceTypeList { get; set; }
        public string IsPosted { get; set; }
        public int Status { get; set; }
        public string StatusMessage { get; set; }
    }

    public class PurchaseReturnModel
    {
        public int PurchaseReturnHeaderId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ReturnNo { get; set; }
        public Nullable<long> SupplierId { get; set; }
        public string SupplierName { get; set; }
        public int InvoiceId { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public string ReturnReason { get; set; }
        public Int64 PurchaseInvoiceId { get; set; }
        public string Description { get; set; }

        public SelectList SupplierList { get; set; }
        public SelectList InvoiceList { get; set; }
        public SelectList ReturnReasonList { get; set; }

        public string hidTempDetail { get; set; }

        public string Status { get; set; }
        public int StatusId { get; set; }

        public bool ShowHideBatchExpiry { get; set; }
    }
}