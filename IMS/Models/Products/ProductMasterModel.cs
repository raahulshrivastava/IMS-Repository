using IMS.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.Models.Products
{
    public class ProductMasterModel
    {
        public Int64 ProductId { get; set; }
        public Int64 StoreId { get; set; }
        public Int64 CategoryId { get; set; }
        public string CategoryDes { get; set; }
        public Int64 BrandId { get; set; }
        public string BrandDes { get; set; }
        public Int64 UnitId { get; set; }
        public string UnitDes { get; set; }
        public Int64? TaxId { get; set; }
        public string TaxDes { get; set; }
        public string ProductName { get; set; }
        public string ItemSkuCode { get; set; }
        public Int32 RecorderQuantity { get; set; }
        public decimal? CessTax { get; set; }
        public Int32 ItemType { get; set; }
        public decimal SalesPriceMRP { get; set; }
        public string RackNo { get; set; }
        public string GenericName { get; set; }
        public string HSNSACCode { get; set; }
        public string Description { get; set; }
        public string AtributeValue { get; set; }
        public Int64? AttributeId { get; set; }
        public Int64? AttributeDetailId { get; set; }
        public SelectList BindCategoryDdl { get; set; }
        public SelectList BindItemTypeDdl { get; set; }
        public SelectList BindTaxDdl { get; set; }
        public SelectList BindUnitDdl { get; set; }
        public SelectList BindBrandDdl { get; set; }
        public SelectList BindAttributeddl { get; set; }
        public SelectList BindAttributeDetailDdl { get; set; }
        public bool CheckIsActive { get; set; }
        public string ItemTypeDescription { get; set; }
        public string hidForward { get; set; }
        public bool HasBatchNumber { get; set; }
        public bool AddProduct { get; set; }
        public Int32 UsedCount{ get; set; }
        public string RackNumber { get; set; }        
        public Int32 AvlQty
        {
            get
            {
                var _AvlCounts = 0;
                if (this.ProductId > 0)
                {
                    _AvlCounts = CommonClass.GetTotalAvailbaleQuantities(this.ProductId);
                    return _AvlCounts;
                }
                return AvlQty;
            }
            set { AvlQty = value; }
        }
    }

}