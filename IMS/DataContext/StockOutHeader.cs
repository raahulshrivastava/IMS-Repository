
namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class StockOutHeader
    {
        [Key]
        public long StockOutHeaderId { get; set; }
        public long StoreId { get; set; }
        public string FinYear { get; set; }
        public string Description { get; set; }
        public Nullable<int> IsDeleted { get; set; }
        public long IncrementedNo { get; set; }
        public System.DateTime StockOutDate { get; set; }
        public string StockOutNo { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
    }
}
