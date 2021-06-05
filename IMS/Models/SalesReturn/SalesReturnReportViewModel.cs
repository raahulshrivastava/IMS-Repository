using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Models.SalesReturn
{
    public class SalesReturnReportViewModel
    {
        public SalesReturnReportViewModel()
        {
            this.DetailList = new List<SalesReturnDetail>();
        }
        public string Date { get; set; }
        public string ReturnNo { get; set; }
        public string CustomerName { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public List<SalesReturnDetail> DetailList { get; set; }
    }

    public class SalesReturnDetail
    {
        public string Product { get; set; }
        public string Quantity { get; set; }
        public string FreeQuantity { get; set; }
        public string TotalQuantity { get; set; }
        public string ReturnQuantity { get; set; }
    }
}