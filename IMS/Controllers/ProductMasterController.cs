using IMS.Business;
using IMS.DataContext;
using IMS.Utilities;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using IMS.Models.Products;
using IMS.Filters;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace IMS.Controllers
{
    [CustomAuthorizationFilter]
    public class ProductMasterController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        public ActionResult Index()
        {
            ProductSearchModel model = new ProductSearchModel();
            model.ProductList = CommonClass.GetProductList();
            model.CategoryList = CommonClass.GetCategoryList();
            model.BrandList = CommonClass.GetBrandList();
            return View(model);
        }

        public ActionResult SearchProductMaster()
        {
            try
            {
                var lst = ProductMasterManager.GetProductHeaderDetail();
                return PartialView("_SearchProductMaster", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult AvailableProductIndex()
        {
            ProductSearchModel model = new ProductSearchModel();
            model.ProductList = CommonClass.GetProductList();
            model.CategoryList = CommonClass.GetCategoryList();
            model.BrandList = CommonClass.GetBrandList();
            return View(model);
        }

        public ActionResult SearchAvailableProduct()
        {
            try
            {
                var lst = ProductMasterManager.GetProductHeaderDetail();
                return PartialView("_SearchAvailableProduct", lst);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public ActionResult ProductMaster(int id = 0)
        {
            try
            {
                ProductMasterModel mas = new ProductMasterModel();
                mas.AddProduct = false;
                if (id > 0)
                {
                    var header = ProductMasterManager.GetValuesHeaderById(id);
                    mas.ProductId = header.ProductId;
                    mas.BrandId = header.BrandId;
                    mas.CategoryId = header.CategoryId;
                    mas.CessTax = header.CessTax;
                    mas.CheckIsActive = header.IsActive == "Y" ? true : false;
                    mas.Description = header.Description;
                    mas.GenericName = header.GenericName;
                    mas.HSNSACCode = header.HSNSACCode;
                    mas.ItemSkuCode = header.ItemSkuCode;
                    mas.ItemType = header.ItemType;
                    mas.ProductName = header.ProductName;
                    mas.RackNo = header.RackNo;
                    mas.RecorderQuantity = header.RecorderQuantity;
                    mas.SalesPriceMRP = header.SalesPriceMRP;
                    mas.StoreId = header.StoreId;
                    mas.TaxId = header.TaxId;
                    mas.UnitId = header.UnitId;
                    mas.HasBatchNumber = header.HasBatchNumber;
                    var det = ProductMasterManager.GetValuesFromProductMasterDetail(id);
                    if (det != null && det.Count() > 0)
                    {
                        var fAdd = "";
                        foreach (var item in det)
                        {
                            string AttributeName = string.Empty;
                            string AttributeDetail = string.Empty;
                            AttributeName = ProductMasterManager.GetAttributeNameById(item.AttributeId);
                            AttributeDetail = ProductMasterManager.GetAttributeDetailNameById(item.AttributeDetailId);
                            fAdd += AttributeName + "!";
                            fAdd += item.AttributeId + "!";
                            fAdd += AttributeDetail + "!";
                            fAdd += item.AttributeDetailId + "!";
                            fAdd += item.AtrtributeValue + "!";
                            fAdd += "$";
                        }

                        mas.hidForward = fAdd.ToString();
                        mas.AddProduct = true;
                    }
                }

                mas.BindCategoryDdl = ProductMasterManager.BindCategory(Convert.ToString(mas.CategoryId));
                mas.BindBrandDdl = ProductMasterManager.BindBrand(Convert.ToString(mas.BrandId));
                mas.BindUnitDdl = ProductMasterManager.BindUnit(Convert.ToString(mas.UnitId));
                mas.BindTaxDdl = ProductMasterManager.BindTax(Convert.ToString(mas.TaxId));
                mas.BindItemTypeDdl = CommonClass.BindItemType(Convert.ToString(mas.ItemType));

                mas.BindAttributeddl = ProductMasterManager.BindAttribute(Convert.ToString(mas.AttributeId));
                mas.BindAttributeDetailDdl = ProductMasterManager.BindAttributeDetail(Convert.ToString(mas.AttributeDetailId));

                return View(mas);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult ProductMaster(ProductMasterModel obj)
        {
            var returnValues = new object();
            try
            {
                ProductMasterHeader header = new ProductMasterHeader();
                if (obj.ProductId > 0)
                {
                    header = ProductMasterManager.UpdateProductMasterHeader(obj);
                }
                else
                {
                    header = ProductMasterManager.InserIntoProductMasterHeader(obj);
                }

                if (!string.IsNullOrEmpty(obj.hidForward))
                {
                    ProductMasterManager.InsertIntoProductMasterDetail(header.ProductId, obj.hidForward);
                }
                returnValues = new { Message = "Item Saved Successfully.", MessageType = (int)Utilities.Enums.Message.Success };
            }
            catch (Exception ex)
            {
                returnValues = new { Message = ex.Message, MessageType = (int)Utilities.Enums.Message.Error };
            }
            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteItem(Int64 id)
        {
            var returnValues = new object();
            try
            {
                ProductMasterManager.DeleteItem(id);
                returnValues = new { Message = "Record deleted Successfully.", MessageType = (int)Utilities.Enums.Message.Success };

            }
            catch (Exception ex)
            {
                returnValues = new { Message = ex.Message.ToString(), MessageType = (int)Utilities.Enums.Message.Success };
            }
            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ProductReport(int productId = 0, int categoryId = 0, int brandId = 0, string productName = "", string brandName = "", string categoryName = "")
        {
            try
            {
                var lst = ProductMasterManager.GetProductHeaderDetail(productId, brandId, categoryId);
                ProductReportViewModel model = new ProductReportViewModel();
                model.ProductList = lst;
                model.ProductId = productId;
                model.BrandId = brandId;
                model.CategoryId = categoryId;
                model.ProductName = productId > 0 ? productName : "";
                model.BrandName = brandId > 0 ? brandName : "";
                model.CategoryName = categoryId > 0 ? categoryName : "";
                ViewBag.ReportTitle = "Product Report";
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ActionResult ProductReorderAndAvailableReport()
        {
            try
            {
                string SQL = @" select (isnull(sum(InQuantity),0) - isnull(sum(OutQuantity),0)) as AvlQty, ProductId, ProductName, RackNo, RecorderQuantity from 
                ( select Quantity as InQuantity, 0 as OutQuantity, PMH.ProductId, PMH.ProductName, PMH.RackNo, PMH.RecorderQuantity from StockInDetailMaster STD inner join StockInHeaderMaster STH on STD.StockInHeaderId = STH.StockInHeaderId inner join ProductMasterHeader PMH on PMH.ProductId = STD.ProductId where STH.IsDeleted = 0 
                union 
                select Quantity as InQuantity, 0 as OutQuantity, PMH.ProductId, PMH.ProductName, PMH.RackNo, PMH.RecorderQuantity from PurchaseInvoiceDetail PID inner join PurchaserInvoiceHeader PIH on PID.PurchaserInvHeaderId = PIH.PurchaseInvHeadId inner join ProductMasterHeader PMH on PMH.ProductId = PID.ProductId where PIH.IsDeleted = 0 
                union 
                select Quantity as InQuantity, 0 as OutQuantity, PMH.ProductId, PMH.ProductName, PMH.RackNo, PMH.RecorderQuantity from SalesInvoiceReturnDetail SIRD inner join SalesInvoiceReturnHeader SIRH on SIRD.SalesRerutnHeaderId = SIRH.SalesInvoiceReturnHeaderId  inner join ProductMasterHeader PMH on PMH.ProductId = SIRD.ProductId where SIRH.IsDeleted = 0 
                union
                select 0 as InQuantity, Quantity as OutQuantity, PMH.ProductId, PMH.ProductName, PMH.RackNo, PMH.RecorderQuantity from StockOutDetailMaster SOD inner join StockOutHeader SOH on SOD.StockOutHeaderId = SOH.StockOutHeaderId inner join ProductMasterHeader PMH on PMH.ProductId = SOD.ProductId where SOH.IsDeleted = 0 
                union 
                select 0 as InQuantity, Quantity as OutQuantity, PMH.ProductId, PMH.ProductName, PMH.RackNo, PMH.RecorderQuantity from SalesInvoiceDetail SLID inner join SalesInvoice SIH on SLID.SalesInvInvoiceId = SIH.Id inner join ProductMasterHeader PMH on PMH.ProductId = SLID.ProductId where SIH.IsDeleted = 0 
                union
                select 0 as InQuantity, Quantity as OutQuantity, PMH.ProductId, PMH.ProductName, PMH.RackNo, PMH.RecorderQuantity from PurchaseInvReturnDetail PRD inner join PurchaseReturnHeader PRH on PRD.PurchaseRerutnHeaderId = PRH.PurchaseReturnHeaderId inner join ProductMasterHeader PMH on PMH.ProductId = PRD.ProductId where PRH.IsDeleted = 0 
                )t group by ProductId, ProductName, RackNo, RecorderQuantity ";
                List<DataRow> List = null;
                List = DbUtility.GetDataTable(new SqlCommand() { CommandText = SQL }).AsEnumerable().ToList();
                ViewBag.result = List;
                ViewBag.cnt = List.Count();

                ViewBag.ReportTitle = "Product Reorder Report";
                return View();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
