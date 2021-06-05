using IMS.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.Models.SupplierPayment
{
    public class SupplierPaymentReportViewModel
    {  
        public string PaymentDate { get; set; }
        public string SupplierName { get; set; }
        public string PaymentNo { get; set; }
        public Nullable<decimal> TotalDue { get; set; }
        public Nullable<decimal> TotalPaid { get; set; }
        public Nullable<decimal> PaymentAmount { get; set; }
        public string Description { get; set; }
        public int ReportType { get; set; }
        public int SupplierId { get; set; }
        public SelectList SupplierList { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    
}