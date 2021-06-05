

namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Utilities;

    public partial class SupplierMaster
    {
        [Key]
        public long Id { get; set; }
        public string SupplierName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string GSTNumber { get; set; }
        public string PANNumber { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<decimal> OpeningBalance { get; set; }
        [NotMapped]
        public Int32 UsedCount
        {
            get
            {
                var _usedCounts = 0;
                if (this.Id > 0)
                {
                    _usedCounts = CommonClass.GetCustomerSupplierUsedRecordCount("Supplier", this.Id);
                    return _usedCounts;
                }
                return UsedCount;
            }
            set { UsedCount = value; }
        }
    }
}
