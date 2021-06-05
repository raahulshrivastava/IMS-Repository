using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Models.StockIn
{
    public class StockInInvoiceReportViewModel
    {
        public StockInInvoiceReportViewModel()
        {
            this.DetailList = new List<StockInDetailList>();
        }
        public string StockInDate { get; set; }
        public string StockInNumber { get; set; }
        public List<StockInDetailList> DetailList { get; set; }
    }

    public class StockInDetailList
    {
        public string Category { get; set; }
        public string Product { get; set; }
        public string Unit { get; set; }
        public string Quantity { get; set; }
        public string BatchNumber { get; set; }
        public string ExpiryDate { get; set; }
    }
}