using ClosedXML.Excel;
using IMS.Business;
using IMS.Filters;
using IMS.Models.StockIn;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IMS.Controllers
{
    [CustomAuthorizationFilter]
    public class StockInController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchStockInMaster()
        {
            try
            {
                List<StockIn> data = new List<StockIn>();
                data = StockManager.SearchStockInDetail();
                return PartialView("_SearchStockInMaster", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        [HttpGet]
        public ActionResult AddEditStockInMaster(Int64 id = 0)
        {
            try
            {
                StockIn stk = new StockIn();
                if (id > 0)
                {
                    var hd = StockManager.GetStockInHeaderDetById(id);
                    stk.StockInDate = hd.StockInDate;
                    stk.StockInNumber = hd.StockInNumber;
                    stk.StockInHeaderId = hd.StockInHeaderId;
                    stk.StoreId = hd.StoreId;
                    stk.FinancialYearId = hd.FinancialYearId;
                    stk.IsDeleted = (int)hd.IsDeleted;
                    stk.Description = hd.Description;

                    var det = StockManager.GetStockInDetById(id);

                    if (det != null && det.Count() > 0)
                    {
                        string fAdd = "";
                        foreach (var item in det)
                        {
                            fAdd += item.CategoryName + "!";
                            fAdd += item.CategoryId + "!";
                            fAdd += item.ProductName + "!";
                            fAdd += item.ProductId + "!";
                            fAdd += item.UnitName + "!";
                            fAdd += item.Quantity + "!";
                            fAdd += item.BatchNo + "!";
                            fAdd += item.ExpiryDate.HasValue ? item.ExpiryDate.Value.ToString("dd-MMM-yyyy") : "" + "!";
                            fAdd += "$";
                        }

                        stk.hidForward = fAdd;
                    }
                }
                BindStockDropDown(stk);
                stk.Status = 0;
                return View(stk);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditStockInMaster(StockIn stk)
        {
            var returnValues = new object();
            try
            {

                if (stk.StockInHeaderId > 0)
                {
                    StockManager.StkInUpdate(stk);
                    stk.Status = (int)Utilities.Enums.Message.Success;
                    stk.ReturnMessage = "Item Updated successfully.";
                }
                else
                {
                    StockManager.InsertIntoStkInHeader(stk);
                    stk.Status = (int)Utilities.Enums.Message.Success;
                    stk.ReturnMessage = "Item added successfully.";
                }
                BindStockDropDown(stk);
            }
            catch (Exception ex)
            {
                stk.Status = (int)Utilities.Enums.Message.Success;
                stk.ReturnMessage = Convert.ToString(ex.Message);
            }

            return View(stk);
        }

        public JsonResult BindProductByCatId(int id = 0)
        {
            return Json(StockManager.BindProductByCategory(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetUnitByProduct(Int64 id = 0)
        {
            return Json(StockManager.GetUnitByPtoduct(id), JsonRequestBehavior.AllowGet);
        }


        public JsonResult DeleteItem(Int64 id)
        {
            var returnValues = new object();
            try
            {
                StockManager.DeleteItem(id);
                returnValues = new { Message = "Record deleted Successfully.", MessageType = (int)Utilities.Enums.Message.Success };

            }
            catch (Exception ex)
            {
                returnValues = new { Message = ex.Message.ToString(), MessageType = (int)Utilities.Enums.Message.Success };
            }

            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }


        public static StockIn BindStockDropDown(StockIn T)
        {
            try
            {
                T.ProductDdl = StockManager.BindProductByCategory(T.CategoryId);
                T.CategoryDdl = CommonClass.GetCategoryList();
                T.UnitTxt = StockManager.GetUnitByPtoduct(T.ProductId);
                T.ShowHideBatchExpiry = CommonClass.GetConfiguration();
                return T;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public ActionResult StockInInvoiceReport(int id = 0)
        {
            try
            {
                StockInInvoiceReportViewModel model = new StockInInvoiceReportViewModel();
                var hd = StockManager.GetStockInHeaderDetById(id);
                model.StockInDate = hd.StockInDate.ToString("dd/MMM/yyyy");
                model.StockInNumber = hd.StockInNumber;
                var det = StockManager.GetStockInDetById(id);
                if (det != null && det.Count() > 0)
                {
                    foreach (var item in det)
                    {
                        StockInDetailList stockInDetailList = new StockInDetailList();
                        stockInDetailList.Category = Convert.ToString(item.CategoryName);
                        stockInDetailList.Product = Convert.ToString(item.ProductName);
                        stockInDetailList.Unit = Convert.ToString(item.UnitName);
                        stockInDetailList.Quantity = Convert.ToString(item.Quantity);
                        if (UserSession.StoreType == 0)
                        {
                            stockInDetailList.BatchNumber = Convert.ToString(item.BatchNo);
                            stockInDetailList.ExpiryDate = item.ExpiryDate.Value != null ? item.ExpiryDate.Value.ToString("dd/MMM/yyyy") : "";
                        }
                        else
                        {
                            stockInDetailList.BatchNumber = "";
                            stockInDetailList.ExpiryDate = null;
                        }
                        model.DetailList.Add(stockInDetailList);
                    }
                }
                ViewBag.ReportTitle = "Stock In Report";
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}