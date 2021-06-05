using IMS.Business;
using IMS.Filters;
using IMS.Models.StockOut;
using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IMS.Controllers
{
    [CustomAuthorizationFilter]
    public class StockOutController : Controller
    {
        JavaScriptSerializer js = new JavaScriptSerializer();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SearchStockOut()
        {
            try
            {
                List<StockIn> data = new List<StockIn>();
                data = StockManager.SearchStockOutDetail();
                return PartialView("_SearchStockOut", data);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        [HttpGet]
        public ActionResult AddEditStockOut(Int64 id = 0)
        {
            try
            {
                StockIn stk = new StockIn();
                if (id > 0)
                {
                    var hd = StockManager.GetStockOutHeaderDetById(id);
                    stk.StockInDate = hd.StockOutDate;
                    stk.StockInNumber = hd.StockOutNo;
                    stk.StockInHeaderId = hd.StockOutHeaderId;
                    stk.StoreId = hd.StoreId;
                    stk.FinancialYearId = int.Parse(hd.FinYear);
                    stk.IsDeleted = (int)hd.IsDeleted;
                    stk.Description = hd.Description;

                    var det = StockManager.GetStkOutDeatil(id);

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
                return View(stk);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult AddEditStockOut(StockIn stk)
        {
            var returnValues = new object();
            try
            {

                if (stk.StockInHeaderId > 0)
                {
                    StockManager.StkOutUpdate(stk);
                    stk.Status = (int)Utilities.Enums.Message.Success;
                    stk.ReturnMessage = "Item Updated successfully.";
                }
                else
                {
                    var hed = StockManager.InsertIntoStkOutHeader(stk);
                    stk.Status = (int)Utilities.Enums.Message.Success;
                    stk.ReturnMessage = "Item Added successfully.";
                }
                BindStockDropDown(stk);
            }
            catch (Exception ex)
            {
                stk.Status = (int)Utilities.Enums.Message.Alert;
                stk.ReturnMessage = Convert.ToString(ex.Message);
            }
            return View(stk);

        }

        // GET: StockOut

        public JsonResult DeleteItemStockOut(Int64 id)
        {
            var returnValues = new object();
            try
            {
                StockManager.DeleteItemStkOut(id);
                returnValues = new { Message = "Record deleted Successfully.", MessageType = (int)Utilities.Enums.Message.Success };

            }
            catch (Exception ex)
            {
                returnValues = new { Message = ex.Message.ToString(), MessageType = (int)Utilities.Enums.Message.Success };
            }

            return Json(js.Serialize(returnValues), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetExpiryDate(Int64 id = 0, string BatchNo = "")
        {
            return Json(CommonClass.GetExpiryDateforBatchNo(id, BatchNo), JsonRequestBehavior.AllowGet);
        }
        public JsonResult BindBatchNoByProductId(int id = 0)
        {
            return Json(CommonClass.GetBatchNumberforProduct(id), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAvailableProductQty(Int64 id = 0, string BatchNo = "")
        {
            return Json(CommonClass.GetTotalAvailbaleQuantities(id, BatchNo), JsonRequestBehavior.AllowGet);
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

        [HttpGet]
        public ActionResult StockOutReport(int id)
        {
            try
            {
                StockOutInvoiceReportViewModel model = new StockOutInvoiceReportViewModel();
                var hd = StockManager.GetStockOutHeaderDetById(id);
                model.StockOutDate = hd.StockOutDate.ToString("dd/MMM/yyyy");
                model.StockOutNumber = hd.StockOutNo;
                var det = StockManager.GetStkOutDeatil(id);
                if (det != null && det.Count() > 0)
                {
                    foreach (var item in det)
                    {
                        StockOutDetailList stockOutDetailList = new StockOutDetailList();
                        stockOutDetailList.Category = Convert.ToString(item.CategoryName);
                        stockOutDetailList.Product = Convert.ToString(item.ProductName);
                        stockOutDetailList.Unit = Convert.ToString(item.UnitName);
                        stockOutDetailList.Quantity = Convert.ToString(item.Quantity);
                        if (UserSession.StoreType == 0)
                        {
                            stockOutDetailList.BatchNumber = Convert.ToString(item.BatchNo);
                            stockOutDetailList.ExpiryDate = item.ExpiryDate.Value != null ? item.ExpiryDate.Value.ToString("dd/MMM/yyyy") : "";
                        }
                        else
                        {
                            stockOutDetailList.BatchNumber = "";
                            stockOutDetailList.ExpiryDate = null;
                        }
                        model.DetailList.Add(stockOutDetailList);
                    }
                }
                ViewBag.ReportTitle = "Stock Out Report";
                return View(model);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}