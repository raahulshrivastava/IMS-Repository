

namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class UserMaster
    {
        [Key]
        public long Id { get; set; }
        public string EmployeeName { get; set; }
        public int UserType { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IsActive { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<long> ModifiedBy { get; set; }
    }
}
