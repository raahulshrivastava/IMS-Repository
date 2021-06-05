
namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Utilities;

    public partial class ProductMasterHeader
    {
        [Key]
        public long ProductId { get; set; }
        public long StoreId { get; set; }
        public long CategoryId { get; set; }
        public long BrandId { get; set; }
        public long UnitId { get; set; }
        public Nullable<long> TaxId { get; set; }
        public string ProductName { get; set; }
        public string ItemSkuCode { get; set; }
        public int RecorderQuantity { get; set; }
        public Nullable<decimal> CessTax { get; set; }
        public int ItemType { get; set; }
        public decimal SalesPriceMRP { get; set; }
        public string RackNo { get; set; }
        public string GenericName { get; set; }
        public string HSNSACCode { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public bool HasBatchNumber { get; set; }
        [NotMapped]
        public Int32 UsedCount
        {
            get
            {
                var _usedCounts = 0;
                if (this.ProductId > 0)
                {
                    _usedCounts = CommonClass.GetProductExistCount(this.ProductId);
                    return _usedCounts;
                }
                return UsedCount;
            }
            set { UsedCount = value; }
        }
    }
}
