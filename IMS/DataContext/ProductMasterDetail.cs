
namespace IMS.DataContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class ProductMasterDetail
    {
        [Key]
        public long ProductDetailId { get; set; }
        public long ProductId { get; set; }
        public string AtrtributeValue { get; set; }
        public long AttributeId { get; set; }
        public long AttributeDetailId { get; set; }
    }
}
