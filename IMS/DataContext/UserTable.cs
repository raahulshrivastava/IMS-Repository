

namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class UserTable
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string ContactNumber { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
        public string Password { get; set; }
        public Nullable<int> NumberofFailedAttempts { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public long ModifiedBy { get; set; }
    }
}
