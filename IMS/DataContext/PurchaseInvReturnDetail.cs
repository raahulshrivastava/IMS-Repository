
namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class PurchaseInvReturnDetail
    {
        [Key]
        public long Id { get; set; }
        public long PurchaseRerutnHeaderId { get; set; }
        public long ProductId { get; set; }
        public string BatchNo { get; set; }
        public Nullable<System.DateTime> ExpiryDate { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<int> FreeQuantity { get; set; }
        public Nullable<int> TotalQuantity { get; set; }
        public Nullable<int> ReturnQuantity { get; set; }
    }
}
