using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Models.PurchaseReturn
{
    public class PurchaseReturnReportViewModel
    {
        public PurchaseReturnReportViewModel()
        {
            this.DetailList = new List<PurchaseReturnList>();
        }
        public string Date { get; set; }
        public string ReturnNo { get; set; }
        public string Supplier { get; set; }
        public string InvoiceNo { get; set; }
        public string InvoiceDate { get; set; }
        public List<PurchaseReturnList> DetailList { get; set; }
    }

    public class PurchaseReturnList
    {
        public string Product { get; set; }
        public int Quantity { get; set; }
        public int FreeQty { get; set; }
        public int TotalQty { get; set; }
        public int ReturnQty { get; set; }
    }
}