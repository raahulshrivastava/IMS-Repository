
namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class StockInHeaderMaster
    {
        [Key]
        public long StockInHeaderId { get; set; }
        public long StoreId { get; set; }
        public long FinancialYearId { get; set; }
        public string Description { get; set; }
        public long IncrementedNo { get; set; }
        public System.DateTime StockInDate { get; set; }
        public string StockInNumber { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<int> IsDeleted { get; set; }
    }
}
