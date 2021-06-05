

namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class PurchaseReturnHeader
    {
        [Key]
        public int PurchaseReturnHeaderId { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ReturnNo { get; set; }
        public Nullable<long> SupplierId { get; set; }
        public string InvoiceNo { get; set; }
        public Nullable<System.DateTime> InvoiceDate { get; set; }
        public int CreatedBy { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public string ReturnReason { get; set; }
        public string Description { get; set; }
        public int IncrementedNo { get; set; }
        public Nullable<int> IsDeleted { get; set; }
    }
}
