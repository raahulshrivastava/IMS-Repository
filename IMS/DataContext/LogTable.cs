
namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class LogTable
    {
        [Key]
        public long Id { get; set; }
        public string Source { get; set; }
        public string Helpline { get; set; }
        public string Message { get; set; }
        public Nullable<long> UserId { get; set; }
        public string UserName { get; set; }
        public string InnerException { get; set; }
        public string StackTrace { get; set; }
    }
}
