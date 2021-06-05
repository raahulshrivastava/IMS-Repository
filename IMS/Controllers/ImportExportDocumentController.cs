using ClosedXML.Excel;
using IMS.Business;
using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using IMS.Models.Products;
using IMS.Filters;

namespace IMS.Controllers
{
    [CustomAuthorizationFilter]
    public class ImportExportDocumentController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        #region Export 
        public ActionResult ExportExcel(int type)
        {
            DataTable dt = new DataTable();
            string fileName = string.Empty;

            switch (type)
            {
                case (int)Enums.Modules.AttributeMaster:
                    dt = ToDataTable<AttributeMaster>(AttributeMasterManager.GetAllDataFromAttributeMaster());
                    fileName = "Attribute";
                    break;
                case (int)Enums.Modules.AttributeDetailMaster:
                    dt = ToDataTable<AttributeModel>(AttributeMasterManager.GetAllDetail());
                    fileName = "Attribute Detail";
                    break;
                case (int)Enums.Modules.BrandMaster:
                    dt = ToDataTable<BrandMaster>(BrandMasterManager.GetAllDetail());
                    fileName = "Brand";
                    break;
                case (int)Enums.Modules.CategoryMaster:
                    dt = ToDataTable<CategoryMaster>(CategoryMasterManager.GetAllDetail());
                    fileName = "Category";
                    break;
                case (int)Enums.Modules.CustomerMaster:
                    dt = ToDataTable<CustomerMaster>(CustomerMasterManager.GetAllDetail());
                    fileName = "Customer";
                    break;
                case (int)Enums.Modules.StoreMaster:
                    dt = ToDataTable<StoreMaster>(StoreMasterManager.GetAllDetail());
                    fileName = "Store";
                    break;
                case (int)Enums.Modules.UserMaster:
                    dt = ToDataTable<UserModel>(UserMasterManager.GetAllDetail());
                    fileName = "User";
                    break;
                case (int)Enums.Modules.SupplierMaster:
                    dt = ToDataTable<SupplierMaster>(SupplierMasterManager.GetAllDetail());
                    fileName = "Supplier";
                    break;
                case (int)Enums.Modules.UnitMaster:
                    dt = ToDataTable<UnitMaster>(UnitMasterManager.GetAllDetail());
                    fileName = "Unit";
                    break;
                case (int)Enums.Modules.TaxMaster:
                    dt = ToDataTable<TaxMaster>(TaxMasterManager.GetAllDetail());
                    fileName = "Tax";
                    break;
                case (int)Enums.Modules.PrefixMaster:
                    dt = ToDataTable<PrefixMaster>(PrefixMasterManager.GetAllDetail());
                    fileName = "Prefix";
                    break;
                case (int)Enums.Modules.ProductMaster:
                    dt = ToDataTable<ProductMasterModel>(ProductMasterManager.GetProductHeaderDetail());
                    fileName = "Product";
                    break;
                case (int)Enums.Modules.StockIn:
                    dt = ToDataTable<StockIn>(StockManager.SearchStockInDetail());
                    fileName = "Stock In";
                    break;
                case (int)Enums.Modules.StockOut:
                    dt = ToDataTable<StockIn>(StockManager.SearchStockOutDetail());
                    fileName = "Stock Out";
                    break;
                case (int)Enums.Modules.PurchaseInvoice:
                    dt = ToDataTable<PurchaserInvoiceHeader>(PurchaseInvoiceManager.GetAllDeatil());
                    fileName = "Purchase Invoice";
                    break;
                case (int)Enums.Modules.PurchaseReturn:
                    dt = ToDataTable<PurchaseReturnModel>(PurchaseInvoiceManager.BindDataGrid().ToList());
                    fileName = "Purchase Return";
                    break;
                case (int)Enums.Modules.SalesInvoice:
                    dt = ToDataTable<SalesInvoice>(SalesManager.GetAllDeatil());
                    fileName = "Sales Invoice";
                    break;
                case (int)Enums.Modules.SalesReturn:
                    fileName = "Sales Return";
                    break;
                default:
                    dt = null;
                    break;
            }


            if (dt != null)
            {
                using (XLWorkbook wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Customers");
                    string handle = Guid.NewGuid().ToString();
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        wb.SaveAs(memoryStream);
                        memoryStream.Position = 0;
                        TempData[handle] = memoryStream.ToArray();
                        var data = new { FileGuid = handle, FileName = fileName };
                        return Json(js.Serialize(data), JsonRequestBehavior.AllowGet);
                    }
                }
            }
            return null;
        }

        [HttpGet]
        public virtual ActionResult Download(string fileGuid, string fileName)
        {
            if (TempData[fileGuid] != null)
            {
                fileName = fileName + ".xlsx";
                byte[] data = TempData[fileGuid] as byte[];
                return File(data, "application/vnd.ms-excel", fileName);
            }
            else
            {
                return new EmptyResult();
            }
        }
        #endregion

        #region Import Excel

        [HttpPost]
        public ActionResult ImportExcel(FormCollection fc)
        {
            string action = string.Empty;
            string controller = string.Empty;
            string message = string.Empty;

            if (Request.Files["file"].ContentLength > 0)
            {
                var typeId = fc["typeId"].ToString();
                var postedFile = Request.Files["file"];
                List<CustomerModel> customers = new List<CustomerModel>();
                string filePath = string.Empty;
                if (postedFile != null)
                {
                    string path = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    filePath = path + Path.GetFileName(postedFile.FileName);
                    string extension = Path.GetExtension(postedFile.FileName);
                    postedFile.SaveAs(filePath);

                    string conString = string.Empty;
                    switch (extension)
                    {
                        case ".xls": //Excel 97-03.
                            conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                            break;
                        case ".xlsx": //Excel 07 and above.
                            conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                            break;
                    }
                    DataTable dt = new DataTable();
                    conString = string.Format(conString, filePath);

                    using (OleDbConnection connExcel = new OleDbConnection(conString))
                    {
                        using (OleDbCommand cmdExcel = new OleDbCommand())
                        {
                            using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                            {

                                cmdExcel.Connection = connExcel;

                                //Get the name of First Sheet.
                                connExcel.Open();
                                DataTable dtExcelSchema;
                                dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                                string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                                connExcel.Close();

                                //Read Data from First Sheet.
                                connExcel.Open();
                                cmdExcel.CommandText = "SELECT * From [" + sheetName + "]";
                                odaExcel.SelectCommand = cmdExcel;
                                odaExcel.Fill(dt);
                                connExcel.Close();
                            }
                        }
                    }

                    dynamic data;

                    if (dt != null)
                    {
                        switch (int.Parse(typeId))
                        {
                            case (int)Enums.Modules.AttributeMaster:
                                if (CheckExcelFormat_Attribute(dt))
                                {
                                    data = PrepareViewModelForAttribute(dt);
                                    AttributeMasterManager.InserIntoAttributeMaster(data);
                                   
                                    message = "Data Imported Successfully."; 
                                }
                                else message = "Excel is not in correct format.";
                                action = "Index";
                                controller = "AttributeMaster";
                                break;

                            case (int)Enums.Modules.AttributeDetailMaster:
                                if (CheckExcelFormat_AttributeDetail(dt))
                                {
                                    data = PrepareViewModelForAttributeDetail(dt);
                                    AttributeMasterManager.InserIntoAttributeDetailMaster(data);
                                    
                                    message = "Data Imported Successfully.";
                                }
                                else message = "Excel is not in correct format.";
                                action = "Index";
                                controller = "AttributeDetailMaster";
                                break;

                            case (int)Enums.Modules.BrandMaster:
                                if (CheckExcelFormat_Brand(dt))
                                {
                                    data = PrepareViewModelForBrand(dt);
                                    BrandMasterManager.InsertIntoBrandMaster(data);
                                   
                                    message = "Data Imported Successfully.";
                                }
                                else message = "Excel is not in correct format.";
                                action = "Index";
                                controller = "BrandMaster";
                                break;

                            case (int)Enums.Modules.CategoryMaster:
                                if (CheckExcelFormat_Category(dt))
                                {
                                    data = PrepareViewModelForCategory(dt);
                                    CategoryMasterManager.InsertIntoCategoryMaster(data);
                                 
                                    message = "Data Imported Successfully.";
                                }
                                else message = "Excel is not in correct format.";
                                action = "Index";
                                controller = "CategoryMaster";
                                break;

                            case (int)Enums.Modules.CustomerMaster:
                                if (CheckExcelFormat_Customer(dt))
                                {
                                    data = PrepareViewModelForCustomers(dt);
                                    CustomerMasterManager.InsertIntoCustomerMaster(data);
                                    
                                    message = "Data Imported Successfully.";
                                }
                                else message = "Excel is not in correct format.";
                                action = "Index";
                                controller = "CustomerMaster";
                                break;

                            case (int)Enums.Modules.StoreMaster:
                                if (CheckExcelFormat_Store(dt))
                                {
                                    data = PrepareViewModelForStore(dt);
                                    StoreMasterManager.InsertIntoStoreMaster(data);
                                    
                                    message = "Data Imported Successfully.";
                                }
                                else message = "Excel is not in correct format.";
                                action = "Index";
                                controller = "StoreMaster";
                                break;

                            case (int)Enums.Modules.UserMaster:
                                if (CheckExcelFormat_User(dt))
                                {
                                    data = PrepareViewModelForUser(dt);
                                    UserMasterManager.InsertIntoUserMaster(data);
                                   
                                    message = "Data Imported Successfully.";
                                }
                                else message = "Excel is not in correct format.";
                                action = "Index";
                                controller = "UserMaster";
                                break;

                            case (int)Enums.Modules.SupplierMaster:
                                if (CheckExcelFormat_Supplier(dt))
                                {
                                    data = PrepareViewModelForSupplier(dt);
                                    SupplierMasterManager.InsertIntoSupplierMaster(data);
                                   
                                    message = "Data Imported Successfully.";
                                }
                                else message = "Excel is not in correct format.";
                                action = "Index";
                                controller = "SupplierMaster";
                                break;

                            case (int)Enums.Modules.UnitMaster:
                                if (CheckExcelFormat_Unit(dt))
                                {
                                    data = PrepareViewModelForUnit(dt);
                                    UnitMasterManager.InsertIntoUnitMaster(data);
                                    message = "Data Imported Successfully.";
                                }
                                else message = "Excel is not in correct format.";
                                action = "Index";
                                controller = "UnitMaster";

                                break;

                            case (int)Enums.Modules.TaxMaster:
                                if (CheckExcelFormat_Tax(dt))
                                {
                                    data = PrepareViewModelForTax(dt);
                                    TaxMasterManager.InsertIntoTaxMaster(data);
                                   
                                    message = "Data Imported Successfully.";
                                }
                                else message = "Excel is not in correct format.";
                                action = "Index";
                                controller = "TaxMaster";
                                break;

                            case (int)Enums.Modules.PrefixMaster:
                                if (CheckExcelFormat_Prefix(dt))
                                {
                                    data = PrepareViewModelForPrefix(dt);
                                    PrefixMasterManager.InsertIntoPrefixMaster(data);
                                    
                                    message = "Data Imported Successfully.";
                                }
                                else message = "Excel is not in correct format.";
                                action = "Index";
                                controller = "PrefixMaster";
                                break;

                            default:
                                dt = null;
                                break;
                        }

                    }
                }


            }
            TempData["Message"] = message;
            return RedirectToAction(action, controller);
        }
        #endregion


        #region Utilities



        [NonAction]
        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        [NonAction]
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        [NonAction]
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

        [NonAction]
        private bool CheckExcelFormat_Attribute(DataTable dt)
        {
            var checkDt = true;
            var columns = AttributeTableColumns();

            foreach (var c in dt.Columns)
                if (!columns.Contains(c))
                {
                    checkDt = false;
                    return checkDt;
                }
                    

            return checkDt;
        }


        [NonAction]
        public static List<string> AttributeTableColumns()
        =>
        new List<string>()
        {
                "AttributeName",
                "Description",
                "IsActive"
        };


        [NonAction]
        private static List<AttributeMaster> PrepareViewModelForAttribute(DataTable dt)
        {
            List<AttributeMaster> attributeMasters = new List<AttributeMaster>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AttributeMaster attributMaster = new AttributeMaster()
                    {
                        AttributeName = Convert.ToString(dr["AttributeName"]),
                        Description = Convert.ToString(dr["Description"]),
                        IsActive = Convert.ToString(dr["IsActive"]),
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                    };

                    attributeMasters.Add(attributMaster);
                }
            }
            return attributeMasters;
        }


        [NonAction]
        public static List<string> AttributeDetailTableColumns()
        =>
        new List<string>()
        {
                "DetailName",
                "Description",
                "IsAcive"
        };

        [NonAction]
        private bool CheckExcelFormat_AttributeDetail(DataTable dt)
        {
            var checkDt = true;
            var columns = AttributeDetailTableColumns();

            foreach (var c in dt.Columns)
                if (!columns.Contains(c))
                    checkDt = false;

            return checkDt;
        }


        [NonAction]
        private static List<AttributeDetailMaster> PrepareViewModelForAttributeDetail(DataTable dt)
        {
            List<AttributeDetailMaster> attributeDetailMasters = new List<AttributeDetailMaster>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    AttributeDetailMaster attributDetailMaster = new AttributeDetailMaster()
                    {
                        DetailName = Convert.ToString(dr["DetailName"]),
                        Description = Convert.ToString(dr["Description"]),
                        IsAcive = Convert.ToString(dr["IsAcive"]),
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                        AttributeId = Convert.ToInt32(dr["AttributeId"])
                    };

                    attributeDetailMasters.Add(attributDetailMaster);
                }
            }
            return attributeDetailMasters;
        }

        [NonAction]
        public static List<string> BrandColumnsTableColumns()
        =>
        new List<string>()
        {
                "BranchName",
                "Description",
                "IsActive"
        };
        [NonAction]
        private bool CheckExcelFormat_Brand(DataTable dt)
        {
            var checkDt = true;
            var columns = BrandColumnsTableColumns();

            foreach (var c in dt.Columns)
                if (!columns.Contains(c))
                    checkDt = false;

            return checkDt;
        }

        [NonAction]
        private static List<BrandMaster> PrepareViewModelForBrand(DataTable dt)
        {
            List<BrandMaster> brands = new List<BrandMaster>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    BrandMaster brand = new BrandMaster()
                    {
                        BranchName = Convert.ToString(dr["BranchName"]),
                        Description = Convert.ToString(dr["Description"]),
                        IsActive = Convert.ToString(dr["IsActive"]),
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                    };

                    brands.Add(brand);
                }
            }
            return brands;
        }

        [NonAction]
        public static List<string> CategoryColumnsTableColumns()
        =>
        new List<string>()
        {
                "CategoryName",
                "Description",
                "IsActive"
        };

        [NonAction]
        private bool CheckExcelFormat_Category(DataTable dt)
        {
            var checkDt = true;
            var columns = CategoryColumnsTableColumns();

            foreach (var c in dt.Columns)
                if (!columns.Contains(c))
                    checkDt = false;

            return checkDt;
        }

        [NonAction]
        private static List<CategoryMaster> PrepareViewModelForCategory(DataTable dt)
        {
            List<CategoryMaster> categories = new List<CategoryMaster>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CategoryMaster category = new CategoryMaster()
                    {
                        CategoryName = Convert.ToString(dr["CategoryName"]),
                        Description = Convert.ToString(dr["Description"]),
                        IsActive = Convert.ToString(dr["IsActive"]),
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                    };

                    categories.Add(category);
                }
            }
            return categories;
        }

        [NonAction]
        public static List<string> CustomerColumnsTableColumns()
        =>
        new List<string>()
        {
                    "CustomerName",
                    "Description",
                    "IsActive",
                    "ContactNumber",
                    "EmailId",
                    "Address",
                    "PanNumber",
                    "OpeningBalance"
        };


        [NonAction]
        private bool CheckExcelFormat_Customer(DataTable dt)
        {
            var checkDt = true;
            var columns = CustomerColumnsTableColumns();

            foreach (var c in dt.Columns)
                if (!columns.Contains(c))
                    checkDt = false;

            return checkDt;
        }

        [NonAction]
        private static List<CustomerMaster> PrepareViewModelForCustomers(DataTable dt)
        {
            List<CustomerMaster> cutomers = new List<CustomerMaster>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    CustomerMaster customer = new CustomerMaster()
                    {
                        CustomerName = Convert.ToString(dr["CustomerName"]),
                        Description = Convert.ToString(dr["Description"]),
                        IsActive = Convert.ToString(dr["IsActive"]),
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                        ContactNumber = Convert.ToString(dr["ContactNumber"]),
                        EmailId = Convert.ToString(dr["EmailId"]),
                        Address = Convert.ToString(dr["Address"]),
                        PanNumber = Convert.ToString(dr["PanNumber"]),
                        OpeningBalance = Convert.ToDecimal(dr["OpeningBalance"]),
                    };

                    cutomers.Add(customer);
                }
            }
            return cutomers;
        }

        [NonAction]
        public static List<string> PrefixColumnsTableColumns()
           =>
           new List<string>()
           {
                        "PrefixName",
                        "Description",
                        "PageNumber",
                        "StartingFrom"
           };

        [NonAction]
        private bool CheckExcelFormat_Prefix(DataTable dt)
        {
            var checkDt = true;
            var columns = PrefixColumnsTableColumns();

            foreach (var c in dt.Columns)
                if (!columns.Contains(c))
                    checkDt = false;

            return checkDt;
        }
        [NonAction]
        private static List<PrefixMaster> PrepareViewModelForPrefix(DataTable dt)
        {
            List<PrefixMaster> prefixs = new List<PrefixMaster>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    PrefixMaster prefix = new PrefixMaster()
                    {
                        PrefixName = Convert.ToString(dr["PrefixName"]),
                        Description = Convert.ToString(dr["Description"]),
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                        PageNumber = Convert.ToString(dr["PageNumber"]),
                        StartingFrom = Convert.ToString(dr["StartingFrom"])
                    };

                    prefixs.Add(prefix);
                }
            }
            return prefixs;
        }

        [NonAction]
        public static List<string> StoreColumnsTableColumns()
        =>
        new List<string>()
        {
                        "StoreName",
                        "Description",
                        "OwnerName",
                        "Address",
                        "City",
                        "State",
                        "GSTINNumber",
                        "DLNumber",
                        "ContactNumber1",
                        "ContactNumber2",
                        "EmailId1",
                        "EmailId2",
                        "Website",
                        "TINNumber",
                        "STNumber",
                        "Logo"
        };

        [NonAction]
        private bool CheckExcelFormat_Store(DataTable dt)
        {
            var checkDt = true;
            var columns = StoreColumnsTableColumns();

            foreach (var c in dt.Columns)
                if (!columns.Contains(c))
                    checkDt = false;

            return checkDt;
        }
        [NonAction]
        private static List<StoreMaster> PrepareViewModelForStore(DataTable dt)
        {
            List<StoreMaster> stores = new List<StoreMaster>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    StoreMaster store = new StoreMaster()
                    {
                        StoreName = Convert.ToString(dr["StoreName"]),
                        Description = Convert.ToString(dr["Description"]),
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                        OwnerName = Convert.ToString(dr["OwnerName"]),
                        Address = Convert.ToString(dr["Address"]),
                        City = Convert.ToString(dr["City"]),
                        State = Convert.ToString(dr["State"]),
                        GSTINNumber = Convert.ToString(dr["GSTINNumber"]),
                        DLNumber = Convert.ToString(dr["DLNumber"]),
                        ContactNumber1 = Convert.ToString(dr["ContactNumber1"]),
                        ContactNumber2 = Convert.ToString(dr["ContactNumber2"]),
                        EmailId1 = Convert.ToString(dr["EmailId1"]),
                        EmailId2 = Convert.ToString(dr["EmailId2"]),
                        Website = Convert.ToString(dr["Website"]),
                        TINNumber = Convert.ToString(dr["TINNumber"]),
                        STNumber = Convert.ToString(dr["STNumber"]),
                        Logo = Convert.ToString(dr["Logo"])
                    };

                    stores.Add(store);
                }
            }
            return stores;
        }


        [NonAction]
        public static List<string> TaxColumnsTableColumns()
        =>
        new List<string>()
        {
                        "TaxName",
                        "Description",
                        "AppliedOn",
                        "CGSTValue",
                        "SGSTValue"
        };


        [NonAction]
        private bool CheckExcelFormat_Tax(DataTable dt)
        {
            var checkDt = true;
            var columns = TaxColumnsTableColumns();

            foreach (var c in dt.Columns)
                if (!columns.Contains(c))
                    checkDt = false;

            return checkDt;
        }
        [NonAction]
        private static List<TaxMaster> PrepareViewModelForTax(DataTable dt)
        {
            List<TaxMaster> taxes = new List<TaxMaster>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    TaxMaster tax = new TaxMaster()
                    {
                        TaxName = Convert.ToString(dr["TaxName"]),
                        Description = Convert.ToString(dr["Description"]),
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                        AppliedOn = Convert.ToString(dr["AppliedOn"]),
                        CGSTValue = Convert.ToDecimal(dr["CGSTValue"]),
                        SGSTValue = Convert.ToDecimal(dr["SGSTValue"])
                    };

                    taxes.Add(tax);
                }
            }
            return taxes;

        }

        [NonAction]
        public static List<string> UnitColumnsTableColumns()
        =>
        new List<string>()
        {
                        "UnitName",
                        "Description",
                        "ConversionUnit",
                        "ConversionQuantity"
        };

        [NonAction]
        private bool CheckExcelFormat_Unit(DataTable dt)
        {
            var checkDt = true;
            var columns = UnitColumnsTableColumns();

            foreach (var c in dt.Columns)
                if (!columns.Contains(c))
                    checkDt = false;

            return checkDt;
        }

        [NonAction]
        private static List<UnitMaster> PrepareViewModelForUnit(DataTable dt)
        {
            List<UnitMaster> units = new List<UnitMaster>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UnitMaster unit = new UnitMaster()
                    {
                        UnitName = Convert.ToString(dr["UnitName"]),
                        Description = Convert.ToString(dr["Description"]),
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                        ConversionUnit = Convert.ToInt64(dr["ConversionUnit"]),
                        ConversionQuantity = Convert.ToInt32(dr["ConversionQuantity"])
                    };

                    units.Add(unit);
                }
            }
            return units;

        }

        [NonAction]
        public static List<string> UserColumnsTableColumns()
        =>
        new List<string>()
        {
                        "EmployeeName",
                        "Description",
                        "UserType",
                        "UserName",
                        "Password"
        };


        [NonAction]
        private bool CheckExcelFormat_User(DataTable dt)
        {
            var checkDt = true;
            var columns = UserColumnsTableColumns();

            foreach (var c in dt.Columns)
                if (!columns.Contains(c))
                    checkDt = false;

            return checkDt;
        }
        [NonAction]
        private static List<UserMaster> PrepareViewModelForUser(DataTable dt)
        {
            List<UserMaster> users = new List<UserMaster>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    UserMaster user = new UserMaster()
                    {
                        EmployeeName = Convert.ToString(dr["EmployeeName"]),
                        Description = Convert.ToString(dr["Description"]),
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                        UserType = Convert.ToInt32(dr["UserType"]),
                        UserName = Convert.ToString(dr["UserName"]),
                        Password = Convert.ToString(dr["Password"])
                    };

                    users.Add(user);
                }
            }
            return users;

        }

        [NonAction]
        public static List<string> SupplierColumnsTableColumns()
        =>
        new List<string>()
        {
                        "SupplierName",
                        "Description",
                        "ContactPerson",
                        "ContactNumber",
                        "City",
                        "Address",
                        "Email",
                        "GSTNumber",
                        "PANNumber",
                        "OpeningBalance"
        };


        [NonAction]
        private bool CheckExcelFormat_Supplier(DataTable dt)
        {
            var checkDt = true;
            var columns = SupplierColumnsTableColumns();

            foreach (var c in dt.Columns)
                if (!columns.Contains(c))
                    checkDt = false;

            return checkDt;
        }

        [NonAction]
        private static List<SupplierMaster> PrepareViewModelForSupplier(DataTable dt)
        {
            List<SupplierMaster> suppliers = new List<SupplierMaster>();
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    SupplierMaster supplier = new SupplierMaster()
                    {
                        SupplierName = Convert.ToString(dr["SupplierName"]),
                        Description = Convert.ToString(dr["Description"]),
                        CreatedOn = DateTime.Now,
                        CreatedBy = 1,
                        ContactPerson = Convert.ToString(dr["ContactPerson"]),
                        ContactNumber = Convert.ToString(dr["ContactNumber"]),
                        City = Convert.ToString(dr["City"]),
                        Address = Convert.ToString(dr["Address"]),
                        Email = Convert.ToString(dr["Email"]),
                        GSTNumber = Convert.ToString(dr["GSTNumber"]),
                        PANNumber = Convert.ToString(dr["PANNumber"]),
                        OpeningBalance = Convert.ToDecimal(dr["OpeningBalance"])
                    };

                    suppliers.Add(supplier);
                }
            }
            return suppliers;

        }
        #endregion

    }
}