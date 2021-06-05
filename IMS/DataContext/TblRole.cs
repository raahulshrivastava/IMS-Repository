
namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class TblRole
    {
        [Key]
        public int Id { get; set; }
        public string Role { get; set; }
        public string Description { get; set; }
    }
}
