

namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Utilities;

    public partial class TaxMaster
    {
        [Key]
        public long Id { get; set; }
        public string TaxName { get; set; }
        public string AppliedOn { get; set; }
        public decimal TotalValue { get; set; }
        public decimal CGSTValue { get; set; }
        public decimal SGSTValue { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> MdifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        [NotMapped]
        public Int32 UsedCount
        {
            get
            {
                var _usedCounts = 0;
                if (this.Id > 0)
                {
                    _usedCounts = CommonClass.GetMasterUsedRecordCount("Tax", this.Id);
                    return _usedCounts;
                }
                return UsedCount;
            }
            set { UsedCount = value; }
        }
    }
}
