

namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class SalesInvoiceDetail
    {
        [Key]
        public long Id { get; set; }
        public long SalesInvInvoiceId { get; set; }
        public int ProductId { get; set; }
        public string BatchNo { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal MPR { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal IGSTAmount { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal IGSTPercentage { get; set; }
        public decimal CGSTPercentage { get; set; }
        public decimal SGSTPercent { get; set; }
        public decimal GrossAmount { get; set; }
        public Nullable<int> FreeQuantity { get; set; }
        public Nullable<int> TotalQauntity { get; set; }
    }
}
