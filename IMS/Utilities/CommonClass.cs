using IMS.DataContext;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace IMS.Utilities
{
    public class CommonClass
    {
        public static bool GetConfiguration()
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var val = db.TblConfigurations.AsNoTracking().Select(a => a.StoreType).FirstOrDefault();
                    if (val == 0 || val == null) { return false; }
                    else { return true; }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SelectList Bindddl(string query)
        {
            List<SelectListItem> selectedList = new List<SelectListItem>();
            SqlCommand cmd = new SqlCommand();
            DataSet ds;
            DataTable dt;
            cmd.CommandText = query;
            ds = DbUtility.GetData(cmd, CommandType.Text);
            if (ds != null)
            {
                dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    selectedList.Add(new SelectListItem() { Text = dr[1].ToString(), Value = dr[0].ToString() });
                }
            }

            SelectList list = new SelectList(selectedList, "Value", "Text");
            return list;
        }

        public static String GetEnumDescription(System.Enum EnumConstant)
        {
            try
            {
                FieldInfo fi = EnumConstant.GetType().GetField(EnumConstant.ToString());
                if (fi == null)
                    return "";
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                    return attributes[0].Description.ToString();
                else
                    return EnumConstant.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SelectList GetSelectList(System.Type pEnumType, object selectedItemValue = null, bool sortByText = false)
        {
            try
            {
                Dictionary<String, Int32> ConstantTypeList = new Dictionary<string, int>();
                foreach (System.Enum enumInstance in System.Enum.GetValues(pEnumType))
                {
                    ConstantTypeList.Add(GetEnumDescription(enumInstance), Convert.ToInt32(enumInstance));
                }

                return new SelectList(ConstantTypeList, "Value", "Key", selectedItemValue);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SelectList GetSupplierList(string selval = "")
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var lst = db.SupplierMasters.AsNoTracking().Where(a => a.IsActive == "Y").ToList();
                    List<SelectListItem> item = new List<SelectListItem>();
                    foreach (var i in lst)
                    {
                        SelectListItem m = new SelectListItem();
                        m.Text = i.SupplierName;
                        m.Value = i.Id.ToString();
                        item.Add(m);
                    }
                    return new SelectList(item, "Value", "Text", selval);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SelectList GetCustomerList(string selval = "")
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var lst = db.CustomerMasters.AsNoTracking().Where(a => a.IsActive == "Y").Select(a => new { a.CustomerName, a.Id }).ToList();
                    List<SelectListItem> item = new List<SelectListItem>();
                    foreach (var i in lst)
                    {
                        SelectListItem m = new SelectListItem();
                        m.Text = i.CustomerName;
                        m.Value = i.Id.ToString();
                        item.Add(m);
                    }
                    return new SelectList(item, "Value", "Text", selval);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SelectList GetCategoryList(string selval = "")
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return new SelectList(db.CategoryMasters.AsNoTracking().Where(a => a.IsActive == "Y").ToList(), "Id", "CategoryName");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SelectList GetProductList(string selval = "")
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var lst = db.ProductMasterHeaders.AsNoTracking().Where(a => a.IsActive == "Y").ToList();
                    return new SelectList(lst, "ProductId", "ProductName", selval);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SelectList GetBrandList(string selval = "")
        {
            try
            {
                using (var db = new IMSContext())
                {
                    var lst = db.BrandMasters.AsNoTracking().Where(a => a.IsActive == "Y").ToList();
                    return new SelectList(lst, "Id", "BranchName", selval);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SelectList BindFinancialPeriod()
        {
            try
            {
                var enumData = (from Utilities.Enums.FinancialYear e in System.Enum.GetValues(typeof(Utilities.Enums.FinancialYear))
                                select new
                                {
                                    Value = (int)e,
                                    Text = e.ToString().Replace("F", "").Insert(4, "-")
                                }).ToList();
                return new SelectList(enumData, "Value", "Text");

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SelectList BindUserType(string selval = "")
        {
            try
            {
                var enumData = (from Utilities.Enums.UserType e in System.Enum.GetValues(typeof(Utilities.Enums.UserType))
                                select new
                                {
                                    Value = (int)e,
                                    Text = e.ToString()
                                }).ToList();
                return new SelectList(enumData, "Value", "Text", selval);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SelectList BindItemType(string selval = "")
        {
            try
            {
                var enumData = (from Utilities.Enums.ItemType e in System.Enum.GetValues(typeof(Utilities.Enums.ItemType))
                                select new
                                {
                                    Value = (int)e,
                                    Text = e.ToString()
                                }).ToList();
                return new SelectList(enumData, "Value", "Text", selval);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SelectList BindInvoiceType(string selval = "")
        {
            try
            {
                var enumData = (from Utilities.Enums.InvoiceType e in System.Enum.GetValues(typeof(Utilities.Enums.InvoiceType))
                                select new
                                {
                                    Value = (int)e,
                                    Text = e.ToString()
                                }).ToList();
                return new SelectList(enumData, "Value", "Text", selval);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static SelectList BindStore(string selval = "")
        {
            try
            {
                using (var db = new IMSContext())
                {
                    return new SelectList(db.StoreMasters.AsNoTracking().Where(a => a.IsActive == "Y").ToList(), "Id", "StoreName");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SelectList EmptySelectList()
        {
            return new SelectList(Enumerable.Empty<SelectListItem>());
        }

        public static int GetTotalAvailbaleQuantities(Int64 productId = 0, string BatchNo = "")
        {
            try
            {
                int totalAvailableQuantities = 0;
                string inQuantityQuery = "";
                string outQuantityQuery = "";
                var inQuantity = "";
                var outQuantity = "";
                if (UserSession.StoreType == 0)
                {
                    inQuantityQuery = $" select isnull(sum(Quantity),0) as InQuantity from ( select Quantity from StockInDetailMaster STD inner join StockInHeaderMaster STH on STD.StockInHeaderId = STH.StockInHeaderId where STD.ProductId = {productId} and STD.BatchNo = '{BatchNo}' and STH.IsDeleted = 0 union select Quantity from PurchaseInvoiceDetail PID inner join PurchaserInvoiceHeader PIH on PID.PurchaserInvHeaderId = PIH.PurchaseInvHeadId where PID.ProductId = {productId} and PID.BatchNo = '{BatchNo}' and PIH.IsDeleted = 0 union select Quantity from SalesInvoiceReturnDetail SIRD inner join SalesInvoiceReturnHeader SIRH on SIRD.SalesRerutnHeaderId = SIRH.SalesInvoiceReturnHeaderId where SIRD.ProductId = {productId} and SIRD.BatchNo = '{BatchNo}' and SIRH.IsDeleted = 0 )t ";
                    inQuantity = DbUtility.ExecuteScalarGetItem(inQuantityQuery);

                    outQuantityQuery = $" select isnull(SUM(Quantity),0) as OutQuantity from ( select Quantity from StockOutDetailMaster SOD inner join StockOutHeader SOH on SOD.StockOutHeaderId = SOH.StockOutHeaderId where SOD.ProductId = {productId} and SOD.BatchNo = '{BatchNo}' and SOH.IsDeleted = 0 union select Quantity from SalesInvoiceDetail SLID inner join SalesInvoice SIH on SLID.SalesInvInvoiceId = SIH.Id where SLID.ProductId = {productId} and SLID.BatchNo = '{BatchNo}' and SIH.IsDeleted = 0 union select Quantity from PurchaseInvReturnDetail PRD inner join PurchaseReturnHeader PRH on PRD.PurchaseRerutnHeaderId = PRH.PurchaseReturnHeaderId where PRD.ProductId = {productId} and PRD.BatchNo = '{BatchNo}' and PRH.IsDeleted = 0 )t ";
                    outQuantity = DbUtility.ExecuteScalarGetItem(outQuantityQuery);
                }
                else
                {
                    inQuantityQuery = $" select isnull(sum(Quantity),0) as InQuantity from ( select Quantity from StockInDetailMaster STD inner join StockInHeaderMaster STH on STD.StockInHeaderId = STH.StockInHeaderId where STD.ProductId = {productId} and STH.IsDeleted = 0 union select Quantity from PurchaseInvoiceDetail PID inner join PurchaserInvoiceHeader PIH on PID.PurchaserInvHeaderId = PIH.PurchaseInvHeadId where PID.ProductId = {productId} and PIH.IsDeleted = 0 union select Quantity from SalesInvoiceReturnDetail SIRD inner join SalesInvoiceReturnHeader SIRH on SIRD.SalesRerutnHeaderId = SIRH.SalesInvoiceReturnHeaderId where SIRD.ProductId = {productId} and SIRH.IsDeleted = 0 )t ";
                    inQuantity = DbUtility.ExecuteScalarGetItem(inQuantityQuery);

                    outQuantityQuery = $" select isnull(SUM(Quantity),0) as OutQuantity from ( select Quantity from StockOutDetailMaster SOD inner join StockOutHeader SOH on SOD.StockOutHeaderId = SOH.StockOutHeaderId where SOD.ProductId = {productId} and SOH.IsDeleted = 0 union select Quantity from SalesInvoiceDetail SLID inner join SalesInvoice SIH on SLID.SalesInvInvoiceId = SIH.Id where SLID.ProductId = {productId} and SIH.IsDeleted = 0 union select Quantity from PurchaseInvReturnDetail PRD inner join PurchaseReturnHeader PRH on PRD.PurchaseRerutnHeaderId = PRH.PurchaseReturnHeaderId where PRD.ProductId = {productId} and PRH.IsDeleted = 0 )t ";
                    outQuantity = DbUtility.ExecuteScalarGetItem(outQuantityQuery);
                }

                totalAvailableQuantities = Convert.ToInt32(inQuantity) - Convert.ToInt32(outQuantity);
                return totalAvailableQuantities;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SelectList GetBatchNumberforProduct(Int64 ProductId)
        {
            try
            {
                string query = $" select distinct t.BatchNo from (select BatchNo from StockInDetailMaster where ProductId = {ProductId} union select BatchNo from PurchaseInvoiceDetail where ProductId = {ProductId} union select BatchNo from SalesInvoiceReturnDetail where ProductId = {ProductId})t where t.BatchNo <> '' ";
                var dt = DbUtility.GetDataTable(new SqlCommand() { CommandText = query });
                var lst = new List<SelectListItem>();
                foreach (DataRow dr in dt.Rows)
                {
                    SelectListItem item = new SelectListItem();
                    item.Text = Convert.ToString(dr["BatchNo"]);
                    item.Value = Convert.ToString(dr["BatchNo"]);
                    lst.Add(item);
                }
                var selectList = new SelectList(lst, "Value", "Text");
                return selectList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetExpiryDateforBatchNo(Int64 ProductId, string BatchNo)
        {
            try
            {
                if (!string.IsNullOrEmpty(BatchNo))
                {
                    string ExpiryDate = "";
                    string query = $" select distinct t.ExpiryDate from (select ExpiryDate from StockInDetailMaster where ProductId = {ProductId} and BatchNo = '{BatchNo}' union select ExpiryDate from PurchaseInvoiceDetail where ProductId = {ProductId} and BatchNo = '{BatchNo}' union select ExpiryDate from SalesInvoiceReturnDetail where ProductId = {ProductId} and BatchNo = '{BatchNo}')t where t.ExpiryDate <> '' ";
                    ExpiryDate = DbUtility.ExecuteScalarGetItem(query);

                    return Convert.ToDateTime(ExpiryDate).ToString("dd-MMM-yyyy");
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Int32 GetDetailUsedRecordCount(string Type, Int64 Id)
        {
            try
            {
                string SubQuery = "";
                Int32 NumSelectCount = 0;

                if (Type == "Attribute")
                { SubQuery = "AttributeId = " + Id; }
                else if (Type == "AttributeDetail")
                { SubQuery = "AttributeDetailId = " + Id; }

                string NumCount = $" select COUNT(*) as NumCount from ProductMasterDetail where {SubQuery} ";
                NumSelectCount = Convert.ToInt32(DbUtility.ExecuteScalarGetItem(NumCount));

                return NumSelectCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Int32 GetProductExistCount(Int64 Id)
        {
            try
            {
                Int32 NumSelectCount = 0;
                if (NumSelectCount == 0)
                {
                    string NumCount = $" select COUNT(*) as NumCount from StockInDetailMaster where ProductId = {Id} ";
                    NumSelectCount = Convert.ToInt32(DbUtility.ExecuteScalarGetItem(NumCount));
                }
                if (NumSelectCount == 0)
                {
                    string NumCount = $" select COUNT(*) as NumCount from StockOutDetailMaster where ProductId = {Id} ";
                    NumSelectCount = Convert.ToInt32(DbUtility.ExecuteScalarGetItem(NumCount));
                }
                if (NumSelectCount == 0)
                {
                    string NumCount = $" select COUNT(*) as NumCount from PurchaseInvoiceDetail where ProductId = {Id} ";
                    NumSelectCount = Convert.ToInt32(DbUtility.ExecuteScalarGetItem(NumCount));
                }
                if (NumSelectCount == 0)
                {
                    string NumCount = $" select COUNT(*) as NumCount from SalesInvoiceDetail where ProductId = {Id} ";
                    NumSelectCount = Convert.ToInt32(DbUtility.ExecuteScalarGetItem(NumCount));
                }
                if (NumSelectCount == 0)
                {
                    string NumCount = $" select COUNT(*) as NumCount from PurchaseInvReturnDetail where ProductId = {Id} ";
                    NumSelectCount = Convert.ToInt32(DbUtility.ExecuteScalarGetItem(NumCount));
                }
                if (NumSelectCount == 0)
                {
                    string NumCount = $" select COUNT(*) as NumCount from SalesInvoiceReturnDetail where ProductId = {Id} ";
                    NumSelectCount = Convert.ToInt32(DbUtility.ExecuteScalarGetItem(NumCount));
                }

                return NumSelectCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Int32 GetCustomerSupplierUsedRecordCount(string Type, Int64 Id)
        {
            try
            {
                string NumCount = "";
                Int32 NumSelectCount = 0;
                if (Type == "Customer")
                {
                    NumCount = $" select COUNT(*) from SalesInvoice where CustomerId = " + Id;
                    NumSelectCount = Convert.ToInt32(DbUtility.ExecuteScalarGetItem(NumCount));
                }
                else if (Type == "Supplier")
                {
                    NumCount = $" select COUNT(*) from PurchaserInvoiceHeader where SupplierID = " + Id;
                    NumSelectCount = Convert.ToInt32(DbUtility.ExecuteScalarGetItem(NumCount));
                }

                return NumSelectCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static Int32 GetMasterUsedRecordCount(string Type, Int64 Id)
        {
            try
            {
                Int32 NumSelectCount = 0;
                string SubQuery = "";

                if (Type == "Brand")
                { SubQuery = "BrandId = " + Id; }
                else if (Type == "Category")
                { SubQuery = "CategoryId = " + Id; }
                else if (Type == "Store")
                { SubQuery = "StoreId = " + Id; }
                else if (Type == "Unit")
                { SubQuery = "UnitId = " + Id; }
                else if (Type == "Tax")
                { SubQuery = "TaxId = " + Id; }

                string NumCount = $" select COUNT(*) as NumCount from ProductMasterHeader where {SubQuery} ";
                NumSelectCount = Convert.ToInt32(DbUtility.ExecuteScalarGetItem(NumCount));

                return NumSelectCount;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}