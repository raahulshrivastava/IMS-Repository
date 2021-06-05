using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Models.StockOut
{
    public class StockOutInvoiceReportViewModel
    {
        public StockOutInvoiceReportViewModel()
        {
            this.DetailList = new List<StockOutDetailList>();
        }
        public string  StockOutDate { get; set; }
        public string StockOutNumber { get; set; }
        public List<StockOutDetailList> DetailList { get; set; }
    }

    public class StockOutDetailList
    {
        public string Category { get; set; }
        public string Product { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public string BatchNumber { get; set; }
        public string ExpiryDate { get; set; }
    }
}