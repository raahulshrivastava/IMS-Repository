using System;
using System.Collections.Generic;
using System.Linq;
using IMS.Utilities;
using System.Web.Mvc;
using IMS.DataContext;
using IMS.Models.Products;

namespace IMS.Business
{
    public class ProductMasterManager
    {
        public static SelectList BindCategory(string selval = "")
        {
            using (var db = new IMSContext())
            {
                return new SelectList(db.CategoryMasters.AsNoTracking().ToList(), "Id", "CategoryName", selval);
            }
        }
        public static SelectList BindBrand(string selval = "")
        {
            using (var db = new IMSContext())
            {
                return new SelectList(db.BrandMasters.AsNoTracking().ToList(), "Id", "BranchName", selval);
            }
        }
        public static SelectList BindAttribute(string selval = "")
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return new SelectList(db.AttributeMasters.AsNoTracking().ToList(), "Id", "AttributeName", selval);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SelectList BindAttributeDetail(string selval = "")
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return new SelectList(db.AttributeDetailMasters.AsNoTracking().ToList(), "Id", "DetailName", selval);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SelectList BindTax(string selval = "")
        {
            using (var db = new IMSContext())
            {
                return new SelectList(db.TaxMasters.AsNoTracking().ToList(), "Id", "TaxName", selval);
            }
        }
        public static SelectList BindUnit(string selval = "")
        {
            using (var db = new IMSContext())
            {
                return new SelectList(db.UnitMasters.AsNoTracking().ToList(), "Id", "UnitName", selval);
            }
        }
        public static ProductMasterHeader GetValuesHeaderById(Int64 id)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.ProductMasterHeaders.AsNoTracking().Where(a => a.ProductId == id).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ProductMasterHeader InserIntoProductMasterHeader(ProductMasterModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    ProductMasterHeader header = new ProductMasterHeader();
                    header.BrandId = model.BrandId;
                    header.CategoryId = model.CategoryId;
                    header.CessTax = model.CessTax;
                    header.Description = model.Description;
                    header.GenericName = model.GenericName;
                    header.HSNSACCode = model.HSNSACCode;

                    if (model.CheckIsActive) { header.IsActive = "Y"; }
                    else { header.IsActive = "N"; }

                    header.ItemSkuCode = model.ItemSkuCode;
                    header.ItemType = model.ItemType;
                    header.ProductName = model.ProductName;
                    header.RackNo = model.RackNo;
                    header.RecorderQuantity = model.RecorderQuantity;
                    header.SalesPriceMRP = model.SalesPriceMRP;
                    header.StoreId = UserSession.StoreId;
                    header.TaxId = model.TaxId;
                    header.UnitId = model.UnitId;
                    header.HasBatchNumber = model.HasBatchNumber;
                    header.CreatedBy = UserSession.Id;
                    header.CreatedOn = DateTime.Now.Date;

                    db.ProductMasterHeaders.Add(header);
                    db.SaveChanges();
                    return header;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ProductMasterHeader UpdateProductMasterHeader(ProductMasterModel model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    ProductMasterHeader header = GetValuesHeaderById(model.ProductId);

                    header.BrandId = model.BrandId;
                    header.CategoryId = model.CategoryId;
                    header.CessTax = model.CessTax;
                    header.Description = model.Description;
                    header.GenericName = model.GenericName;
                    header.HSNSACCode = model.HSNSACCode;

                    if (model.CheckIsActive) { header.IsActive = "Y"; }
                    else { header.IsActive = "N"; }

                    header.ItemSkuCode = model.ItemSkuCode;
                    header.ItemType = model.ItemType;
                    header.ProductName = model.ProductName;
                    header.RackNo = model.RackNo;
                    header.RecorderQuantity = model.RecorderQuantity;
                    header.SalesPriceMRP = model.SalesPriceMRP;
                    header.StoreId = UserSession.StoreId;
                    header.TaxId = model.TaxId;
                    header.UnitId = model.UnitId;
                    header.HasBatchNumber = model.HasBatchNumber;
                    header.ModifiedBy = UserSession.Id;
                    header.ModifiedOn = DateTime.Now.Date;

                    db.Entry(header).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return header;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ProductMasterDetail> InsertIntoProductMasterDetail(Int64 productid, string val)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    int icountdet = 0;
                    icountdet = db.ProductMasterDetails.AsNoTracking().Where(a => a.ProductId == productid).Count();
                    if (icountdet > 0)
                    {
                        var lstdet = db.ProductMasterDetails.Where(a => a.ProductId == productid).ToList();
                        foreach (var i in lstdet)
                        {
                            db.Entry(i).State = System.Data.Entity.EntityState.Deleted;
                            db.SaveChanges();
                        }
                    }

                    string[] datarows = val.Split('$');
                    List<ProductMasterDetail> lst = new List<ProductMasterDetail>();
                    for (int i = 0; i < datarows.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(datarows[i].ToString()))
                        {
                            string[] datacol = datarows[i].Split('!');

                            ProductMasterDetail det = new ProductMasterDetail();
                            det.AtrtributeValue = Convert.ToString(datacol[4]);
                            det.AttributeDetailId = int.Parse(datacol[3]);
                            det.AttributeId = int.Parse(datacol[1]);
                            det.ProductId = productid;
                            db.ProductMasterDetails.Add(det);
                            db.SaveChanges();
                            lst.Add(det);

                        }
                    }

                    return lst;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static ProductMasterDetail UpdateProductMasterDetail(ProductMasterDetail model)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    ProductMasterDetail det = new ProductMasterDetail();
                    det.AtrtributeValue = model.AtrtributeValue;
                    det.AttributeDetailId = model.AttributeDetailId;
                    det.AttributeId = model.AttributeId;

                    db.Entry(det).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return det;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ProductMasterDetail> GetValuesFromProductMasterDetail(int productid)
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.ProductMasterDetails.AsNoTracking().Where(a => a.ProductId == productid).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ProductMasterHeader> GetValuesFromProductMasterHeader()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return db.ProductMasterHeaders.AsNoTracking().ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static List<ProductMasterModel> GetProductHeaderDetail(int productId = 0, int brandId = 0, int categoryId = 0)
        {
            using (var db = new IMSContext())
            {
                var query = (from hd in db.ProductMasterHeaders.AsNoTracking()
                             join bd in db.BrandMasters.AsNoTracking() on hd.BrandId equals bd.Id
                             join ct in db.CategoryMasters.AsNoTracking() on hd.CategoryId equals ct.Id
                             join ut in db.UnitMasters.AsNoTracking() on hd.UnitId equals ut.Id
                             join tx in db.TaxMasters.AsNoTracking() on hd.TaxId equals tx.Id
                             where bd.IsActive == "Y"
                             && ct.IsActive == "Y"
                             && ut.IsActive == "Y"
                             && tx.IsActive == "Y"
                             select new { hd, bd, ct, ut, tx }).AsQueryable();

                if (productId > 0)
                    query = query.Where(a => a.hd.ProductId == productId);

                if (brandId > 0)
                    query = query.Where(a => a.bd.Id == brandId);

                if (categoryId > 0)
                    query = query.Where(a => a.ct.Id == categoryId);

                var lst = query.Select(a => new ProductMasterModel
                {
                    ProductId = a.hd.ProductId,
                    BrandDes = a.bd.BranchName,
                    CategoryDes = a.ct.CategoryName,
                    UnitDes = a.ut.UnitName,
                    TaxDes = a.tx.TaxName,
                    CessTax = a.hd.CessTax,
                    Description = a.hd.Description,
                    GenericName = a.hd.GenericName,
                    ProductName = a.hd.ProductName,
                    SalesPriceMRP = a.hd.SalesPriceMRP,
                    RecorderQuantity = a.hd.RecorderQuantity,
                    RackNo = a.hd.RackNo,
                    HSNSACCode = a.hd.HSNSACCode,
                    ItemType = a.hd.ItemType,
                    ItemSkuCode = a.hd.ItemSkuCode
                }).OrderBy(a => a.ProductName).ToList();

                foreach (var i in lst)
                {
                    i.ItemTypeDescription = System.Enum.GetName(typeof(IMS.Utilities.Enums.ItemType), (int)i.ItemType);
                }
                return lst;
            }
        }
        public static void DeleteItem(Int64 id)
        {
            using (var db = new IMSContext())
            {
                var frt = db.ProductMasterHeaders.AsNoTracking().Where(a => a.ProductId == id).First();
                db.Entry(frt).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

                var lst = db.ProductMasterDetails.AsNoTracking().Where(a => a.ProductId == id).ToList();
                foreach (var i in lst)
                {
                    db.Entry(i).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
            }
        }
        public static string GetAttributeNameById(Int64 id)
        {
            using (var db = new IMSContext())
            {
                return db.AttributeMasters.AsNoTracking().Where(a => a.Id == id).Select(a => a.AttributeName).FirstOrDefault();
            }
        }
        public static string GetAttributeDetailNameById(Int64 id)
        {
            using (var db = new IMSContext())
            {
                return db.AttributeDetailMasters.AsNoTracking().Where(a => a.Id == id).Select(a => a.DetailName).FirstOrDefault();
            }
        }        
    }
}