

namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class StockOutDetailMaster
    {
        [Key]
        public long StockOuDetailId { get; set; }
        public long StockOutHeaderId { get; set; }
        public long CategoryId { get; set; }
        public long ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public string BatchNo { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<long> UnitId { get; set; }
    }
}
