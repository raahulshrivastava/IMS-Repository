using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Models.SalesInvoices
{
    public class SalesInvoiceReportViewModel
    {
        public string Date { get; set; }
        public string CustomerName { get; set; }
        public string SalesInvoiceType   { get; set; }
        public string SalesInvoiceNumber { get; set; }
        public string InvoiceDate { get; set; }
        public Nullable<decimal> TotalCGST { get; set; }
        public Nullable<decimal> TotalSGST { get; set; }
        public Nullable<decimal> TotalIGST { get; set; }
        public Nullable<decimal> TotalTaxAmount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> ExtraAmount { get; set; }
        public Nullable<decimal> FinalAmount { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public List<SalesInvoiceDetailList> DetailList { get; set; }
    }
    public class SalesInvoiceDetailList
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public string ChallanNo { get; set; }
        public string BatchNo { get; set; }
        public string ExpiryDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal MPR { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal TaxableAmount { get; set; }
        public decimal IGSTAmount { get; set; }
        public decimal CGSTAmount { get; set; }
        public decimal SGSTAmount { get; set; }
        public decimal IGSTPercentage { get; set; }
        public decimal CGSTPercentage { get; set; }
        public decimal SGSTPercent { get; set; }
        public decimal GrossAmount { get; set; }
        public Nullable<int> FreeQuantity { get; set; }
        public Nullable<int> TotalQauntity { get; set; }
        public string GstType { get; set; }
    }
}