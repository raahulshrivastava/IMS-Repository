

namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Utilities;

    public partial class StoreMaster
    {
        [Key]
        public long Id { get; set; }
        public string StoreName { get; set; }
        public string OwnerName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string GSTINNumber { get; set; }
        public string DLNumber { get; set; }
        public string Description { get; set; }
        public string ContactNumber1 { get; set; }
        public string ContactNumber2 { get; set; }
        public string EmailId1 { get; set; }
        public string EmailId2 { get; set; }
        public string Website { get; set; }
        public string TINNumber { get; set; }
        public string STNumber { get; set; }
        public string IsActive { get; set; }
        public string Logo { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
        public Nullable<int> StoreType { get; set; }
        public Nullable<int> PaymentType { get; set; }
        [NotMapped]
        public Int32 UsedCount
        {
            get
            {
                try
                {
                    var _usedCounts = 0;
                    if (this.Id > 0)
                    {
                        _usedCounts = CommonClass.GetMasterUsedRecordCount("Store", this.Id);
                        return _usedCounts;
                    }
                    return UsedCount;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
            set { UsedCount = value; }
        }
    }
}
