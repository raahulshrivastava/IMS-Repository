using IMS.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IMS.Models.CustomerPayment
{
    public class CustomerPaymentReportViewModel
    {  
        public string PaymentDate { get; set; }
        public string CustomerName { get; set; }
        public string PaymentNo { get; set; }
        public Nullable<decimal> TotalDue { get; set; }
        public Nullable<decimal> TotalPaid { get; set; }
        public Nullable<decimal> PaymentAmount { get; set; }
        public string Description { get; set; }
        public int CustomerId { get; set; }
        public int ReportType { get; set; }
        public SelectList CustomerList { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
    }
    
}