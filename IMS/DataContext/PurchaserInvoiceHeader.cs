

namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class PurchaserInvoiceHeader
    {
        [Key]
        public long PurchaseInvHeadId { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime SupplierBillDate { get; set; }
        public string SupplierBillNo { get; set; }
        public string InvoiceNo { get; set; }
        public int IncrementNo { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<decimal> TotalCGST { get; set; }
        public Nullable<decimal> TotalSGST { get; set; }
        public Nullable<decimal> TotalIGST { get; set; }
        public Nullable<decimal> TotalTaxAmount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> ExtraAmount { get; set; }
        public Nullable<decimal> FinalAmount { get; set; }
        public Nullable<decimal> FinalDiscount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public int FinancialId { get; set; }
        public int StoreId { get; set; }
        public Nullable<int> SupplierID { get; set; }
        public string Description { get; set; }
        public string InvoiceType { get; set; }
        public Nullable<int> IsPosted { get; set; }
        public Nullable<int> IsDeleted { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
    }
}
