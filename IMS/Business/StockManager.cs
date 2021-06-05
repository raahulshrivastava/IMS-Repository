using System;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using IMS.DataContext;
using IMS.Utilities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IMS.Business
{
    public class StockManager
    {
        public static StockInHeaderMaster GetStockInHeaderDetById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.StockInHeaderMasters.AsNoTracking().Where(a => a.StockInHeaderId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<StockIn> GetStockInDetById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var detail = (from det in db.StockInDetailMasters.AsNoTracking()
                                  join pr in db.ProductMasterHeaders.AsNoTracking() on det.ProductId equals pr.ProductId
                                  join ct in db.CategoryMasters.AsNoTracking() on det.CategoryId equals ct.Id
                                  join ut in db.UnitMasters.AsNoTracking() on det.UnitId equals ut.Id
                                  where det.StockInHeaderId == id
                                  select new StockIn
                                  {
                                      ProductName = pr.ProductName,
                                      ProductId = pr.ProductId,
                                      CategoryId = ct.Id,
                                      CategoryName = ct.CategoryName,
                                      Quantity = (int)det.Quantity,
                                      StockInHeaderId = det.StockInHeaderId,
                                      UnitName = ut.UnitName,
                                      BatchNo = det.BatchNo,
                                      ExpiryDate = det.ExpiryDate
                                  }).ToList();
                    return detail;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static SelectList BindProductByCategory(Int64 categoryid = 0, string selval = "")
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var lst = db.ProductMasterHeaders.AsNoTracking().Where(a => a.CategoryId == categoryid).ToList();
                    var retlist = new SelectList(lst, "ProductId", "ProductName", selval);
                    return retlist;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<StockIn> SearchStockInDetail(Int64 headerid = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var data = (from stk in db.StockInHeaderMasters.AsNoTracking()
                                join user in db.UserMasters.AsNoTracking() on stk.CreatedBy equals user.Id
                                where stk.IsDeleted == 0 && stk.StoreId == UserSession.StoreId
                                && user.IsActive == "Y"
                                select new StockIn
                                {
                                    StockInNumber = stk.StockInNumber,
                                    StockInDate = stk.StockInDate,
                                    StockInHeaderId = stk.StockInHeaderId,
                                    CreatedBy = user.EmployeeName,
                                    CreatedOn = stk.CreatedOn
                                }).OrderByDescending(a=>a.StockInDate).ToList();

                    if (headerid > 0)
                    {
                        data = data.Where(a => a.StockInHeaderId == headerid).ToList();
                    }

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string GetUnitByPtoduct(Int64 productid = 0, string selval = "")
        {
            try
            {
                using (var db = new IMSContext())
                {
                    if (productid > 0)
                    {
                        var pUnitid = db.ProductMasterHeaders.AsNoTracking().Where(a => a.ProductId == productid).Select(a => a.UnitId).FirstOrDefault();
                        var unit = db.UnitMasters.AsNoTracking().Where(a => a.Id == pUnitid).Select(a => new { a.UnitName, a.Id }).FirstOrDefault();

                        var stockInDetails = db.StockInDetailMasters.Where(a => a.ProductId == productid).Select(a => new { a.Quantity, a.BatchNo, a.ExpiryDate }).FirstOrDefault();

                        string result = string.Empty;
                        result = unit.Id + "!";
                        result += unit.UnitName + "!";
                        result += stockInDetails != null ? Convert.ToString(stockInDetails.Quantity) : "" + "!";
                        result += stockInDetails != null ? Convert.ToString(stockInDetails.BatchNo) : "" + "!";
                        result += stockInDetails != null ? Convert.ToString(stockInDetails.ExpiryDate) : "" + "!";
                    
                        return result;
                    }
                    else return string.Empty;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static StockInHeaderMaster InsertIntoStkInHeader(StockIn stk)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    StockInHeaderMaster hed = new StockInHeaderMaster();
                    hed.CreatedBy = UserSession.Id;
                    hed.CreatedOn = DateTime.Now.Date;
                    hed.Description = stk.Description;
                    hed.StoreId = UserSession.StoreId;
                    hed.FinancialYearId = int.Parse(UserSession.FinYear);
                    hed.IsDeleted = 0;
                    var prefix = db.PrefixMasters.AsNoTracking().Where(a => a.PrefixName == "STKIN").Select(a => new { a.StartingFrom, a.PrefixName }).FirstOrDefault();
                    Int64 incrementno = db.StockInHeaderMasters.AsNoTracking().OrderByDescending(a => a.IncrementedNo).Select(a => a.IncrementedNo).FirstOrDefault();
                    hed.IncrementedNo = incrementno + 1;
                    var stooutnp = incrementno + Int64.Parse(prefix.StartingFrom) + 1;
                    hed.StockInNumber = prefix.PrefixName + "-" + stooutnp;
                    hed.StockInDate = (DateTime)stk.StockInDate;

                    db.StockInHeaderMasters.Add(hed);
                    db.SaveChanges();

                    stk.StockInHeaderId = hed.StockInHeaderId;
                    if (!string.IsNullOrEmpty(stk.hidForward))
                    {
                        StockManager.InsertIntoStkInDetail(stk);
                    }
                    return hed;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertIntoStkInDetail(StockIn stk)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    if (!string.IsNullOrEmpty(stk.hidForward))
                    {
                        string[] rows = stk.hidForward.Split('$');
                        for (int r = 0; r < rows.Length; r++)
                        {
                            if (!string.IsNullOrEmpty(rows[r]))
                            {
                                string[] col = rows[r].Split('!');
                                StockInDetailMaster det = new StockInDetailMaster();
                                det.Quantity = int.Parse(col[5]);
                                var productid = Int64.Parse(col[3]);
                                Int64 unitid = db.ProductMasterHeaders.AsNoTracking().Where(a => a.ProductId == productid).Select(a => a.UnitId).FirstOrDefault();
                                det.UnitId = unitid;
                                det.CategoryId = int.Parse(col[1]);
                                det.ProductId = productid;
                                det.StockInHeaderId = stk.StockInHeaderId;

                                if (UserSession.StoreType == 0)
                                {
                                    det.BatchNo = Convert.ToString(col[6]);
                                    det.ExpiryDate = DateTime.Parse(col[7]);
                                }
                                else
                                {
                                    det.BatchNo = "";
                                    det.ExpiryDate = null;
                                }

                                db.StockInDetailMasters.Add(det);
                                db.SaveChanges();
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void StkInUpdate(StockIn stk)
        {
            using (var db = new IMSContext())
            {
                var lst = db.StockInDetailMasters.AsNoTracking().Where(a => a.StockInHeaderId == stk.StockInHeaderId).ToList();
                foreach (var i in lst)
                {
                    var detail = db.StockInDetailMasters.AsNoTracking().Where(a => a.StockInDetailId == i.StockInDetailId).FirstOrDefault();
                    db.Entry(detail).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }

                InsertIntoStkInDetail(stk);

                StockInHeaderMaster hed = db.StockInHeaderMasters.Where(a => a.StockInHeaderId == stk.StockInHeaderId).FirstOrDefault(); ;
                hed.ModifiedBy = UserSession.Id;
                hed.ModifiedOn = DateTime.Now.Date;
                hed.Description = stk.Description;
                hed.StockInDate = (DateTime)stk.StockInDate;
                db.Entry(hed).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        public static void DeleteItem(Int64 id)
        {
            using (var db = new IMSContext())
            {
                var frt = db.StockInHeaderMasters.AsNoTracking().Where(a => a.StockInHeaderId == id).FirstOrDefault();
                frt.IsDeleted = 1;
                frt.ModifiedBy = UserSession.Id;
                frt.ModifiedOn = DateTime.Now.Date;
                db.Entry(frt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static List<StockIn> SearchStockOutDetail(Int64 headerid = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var data = (from hd in db.StockOutHeaders.AsNoTracking()
                                join u in db.UserMasters.AsNoTracking() on hd.CreatedBy equals u.Id
                                where hd.IsDeleted == 0 && hd.StoreId == UserSession.StoreId
                                && u.IsActive == "Y"
                                select new StockIn
                                {
                                    StockInNumber = hd.StockOutNo,
                                    StockInDate = hd.StockOutDate,
                                    CreatedBy = u.EmployeeName,
                                    CreatedOn = hd.CreatedOn,
                                    StockInHeaderId = hd.StockOutHeaderId,
                                }).OrderByDescending(a => a.StockInDate).ToList();

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static List<StockIn> GetStkOutDeatil(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var detail = (from det in db.StockOutDetailMasters.AsNoTracking()
                                  join pr in db.ProductMasterHeaders.AsNoTracking() on det.ProductId equals pr.ProductId
                                  join ct in db.CategoryMasters.AsNoTracking() on det.CategoryId equals ct.Id
                                  join ut in db.UnitMasters.AsNoTracking() on det.UnitId equals ut.Id
                                  where det.StockOutHeaderId == id
                                  select new StockIn
                                  {
                                      ProductName = pr.ProductName,
                                      ProductId = pr.ProductId,
                                      CategoryId = ct.Id,
                                      CategoryName = ct.CategoryName,
                                      Quantity = (int)det.Quantity,
                                      StockInHeaderId = det.StockOutHeaderId,
                                      UnitName = ut.UnitName,
                                      BatchNo = det.BatchNo,
                                      ExpiryDate = det.ExpiryDate

                                  }).ToList();
                    return detail;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static StockOutHeader GetStockOutHeaderDetById(Int64 id = 0)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.StockOutHeaders.AsNoTracking().Where(a => a.StockOutHeaderId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static void InsertIntoStkOutDetail(StockIn stk)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    if (!string.IsNullOrEmpty(stk.hidForward))
                    {

                        string[] rows = stk.hidForward.Split('$');

                        for (int r = 0; r < rows.Length; r++)
                        {
                            if (!string.IsNullOrEmpty(rows[r]))
                            {
                                string[] col = rows[r].Split('!');
                                StockOutDetailMaster det = new StockOutDetailMaster();
                                det.Quantity = int.Parse(col[5]);
                                var productid = Int64.Parse(col[3]);
                                Int64 unitid = db.ProductMasterHeaders.AsNoTracking().Where(a => a.ProductId == productid).Select(a => a.UnitId).FirstOrDefault();
                                det.UnitId = unitid;
                                det.CategoryId = int.Parse(col[1]);
                                det.ProductId = productid;
                                det.StockOutHeaderId = stk.StockInHeaderId;
                                if (UserSession.StoreType == 0)
                                {
                                    det.BatchNo = Convert.ToString(col[6]);
                                    det.ExpiryDate = DateTime.Parse(col[7]);
                                }
                                else
                                {
                                    det.BatchNo = "";
                                    det.ExpiryDate = null;
                                }

                                db.StockOutDetailMasters.Add(det);
                                db.SaveChanges();
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static StockOutHeader InsertIntoStkOutHeader(StockIn stk)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    StockOutHeader hed = new StockOutHeader();
                    hed.CreatedBy = UserSession.Id;
                    hed.CreatedOn = DateTime.Now.Date;
                    hed.Description = stk.Description;
                    hed.StoreId = UserSession.StoreId;
                    hed.FinYear = UserSession.FinYear;
                    hed.IsDeleted = 0;
                    var prefix = db.PrefixMasters.AsNoTracking().Where(a => a.PrefixName == "STKOUT").Select(a => new { a.StartingFrom, a.PrefixName }).FirstOrDefault();
                    Int64 incrementno = db.StockOutHeaders.AsNoTracking().OrderByDescending(a => a.IncrementedNo).Select(a => a.IncrementedNo).FirstOrDefault();
                    hed.IncrementedNo = incrementno + 1;
                    var stockoutnp = int.Parse(prefix.StartingFrom) + incrementno + 1;
                    hed.StockOutNo = prefix.PrefixName + "-" + stockoutnp.ToString();
                    hed.StockOutDate = (DateTime)stk.StockInDate;
                    db.StockOutHeaders.Add(hed);
                    db.SaveChanges();

                    stk.StockInHeaderId = hed.StockOutHeaderId;
                    if (!string.IsNullOrEmpty(stk.hidForward))
                    {
                        StockManager.InsertIntoStkOutDetail(stk);
                    }

                    return hed;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void StkOutUpdate(StockIn stk)
        {
            using (var db = new IMSContext())
            {
                var lst = db.StockOutDetailMasters.AsNoTracking().Where(a => a.StockOutHeaderId == stk.StockInHeaderId).ToList();
                foreach (var i in lst)
                {
                    db.Entry(i).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }

                InsertIntoStkOutDetail(stk);

                StockOutHeader hed = db.StockOutHeaders.Where(a => a.StockOutHeaderId == stk.StockInHeaderId).FirstOrDefault();
                hed.ModifiedBy = UserSession.Id;
                hed.ModifiedOn = DateTime.Now.Date;
                hed.Description = stk.Description;
                hed.StockOutDate = (DateTime)stk.StockInDate;
                hed.FinYear = UserSession.FinYear;
                db.Entry(hed).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public static void DeleteItemStkOut(Int64 id)
        {
            using (var db = new IMSContext())
            {
                var frt = db.StockOutHeaders.AsNoTracking().Where(a => a.StockOutHeaderId == id).FirstOrDefault();
                frt.IsDeleted = 1;
                db.Entry(frt).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
    public class StockIn
    {
        public Int64 StockInHeaderId { get; set; }
        public Int64 StoreId { get; set; }
        public Int64 FinancialYearId { get; set; }
        public string Description { get; set; }
        public Int32 IsDeleted { get; set; }
        public Int64 IncrementedNo { get; set; }
        public DateTime? StockInDate { get; set; }
        public string StockInNumber { get; set; }

        public Int64 StockInDetailId { get; set; }

        public Int64 CategoryId { get; set; }
        public Int64 ProductId { get; set; }
        public string UnitTxt { get; set; }
        public Int64 UnitId { get; set; }
        public Int32 Quantity { get; set; }
        public string BatchNo { get; set; }
        public DateTime? ExpiryDate { get; set; }

        public SelectList CategoryDdl { get; set; }
        public SelectList ProductDdl { get; set; }
        public string hidForward { get; set; }

        public int Configuration { get; set; }
        public bool ShowHideBatchExpiry { get; set; }

        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }

        public int AvalibleQuantities { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int Status { get; set; }
        public string ReturnMessage { get; set; }

    }
}