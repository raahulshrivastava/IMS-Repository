using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Models.Products
{

    public class ProductMasterDetailModel
    {
        public Int64 ProductDetailId { get; set; }
        public Int64 ProductId { get; set; }
        public Int64 AttributeId { get; set; }
        public Int64 AttributeDetailId { get; set; }
        public string AttributeValue { get; set; }
    }
}