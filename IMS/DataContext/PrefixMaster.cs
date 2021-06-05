
namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class PrefixMaster
    {
        [Key]
        public long Id { get; set; }
        public string PrefixName { get; set; }
        public string PageNumber { get; set; }
        public string StartingFrom { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
    }
}
