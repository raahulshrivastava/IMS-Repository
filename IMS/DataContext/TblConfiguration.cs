

namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class TblConfiguration
    {
        [Key]
        public long Id { get; set; }
        public int StoreType { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
    }
}
