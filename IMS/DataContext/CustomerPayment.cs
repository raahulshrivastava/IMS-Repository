
namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Utilities;

    public partial class CustomerPayment
    {
        [Key]
        public long Id { get; set; }
        public Nullable<int> SaleInvoiceId { get; set; }
        public int CustomerId { get; set; }
        public decimal PaymentAmount { get; set; }
        public string Description { get; set; }
        public System.DateTime PaymentDate { get; set; }

        public Nullable<int> IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<int> IsPosted { get; set; }
        public string PaymentNo { get; set; }
        public int IncrementNo { get; set; }
        public decimal TotalDue { get; set; }
        public decimal TotalPaid { get; set; }
        public int StoreId { get; set; }
        public int FinancialId { get; set; }
    }
}
