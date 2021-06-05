

namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class SalesInvoiceReturnHeader
    {
        [Key]
        public int SalesInvoiceReturnHeaderId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ReturnNo { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public string ReturnReason { get; set; }
        public string Description { get; set; }
        public Nullable<int> IncrementedNo { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    }
}
