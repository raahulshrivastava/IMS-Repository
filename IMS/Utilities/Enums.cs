using System;
using System.ComponentModel;
using System.Reflection;

namespace IMS.Utilities
{
    public class Enums
    {
        public enum Message
        {
            Success = 1,
            Alert = 2,
            Error = 3
        }

        public enum FinancialYear
        {
            [Description("2018 - 2019")]
            F20182019 = 1,
            [Description("2019 - 2020")]
            F20192020 = 2
        }


        public enum Store
        {
            [Description("Store Product")]
            StoreProduct = 1,
            [Description("Store Service")]
            StoreService = 2
        }

        public enum ItemType
        {
            [Description("Goods")]
            Goods = 1,
            [Description("Services")]
            Services = 2
        }

        public enum UserType
        {
            Admin = 1,
            Normal = 2
        }
        public enum InvoiceType
        {
            [Description("Cash")]
            Cash = 1,
            [Description("Credit")]
            Credit = 2
        }
        public enum InvoicePosted
        {
            [Description("Not Posted")]
            NotPosted = 0,
            [Description("Posted")]
            Posted = 1
        }

        public enum TaxType
        {
            IGST = 1,
            GST = 2
        }

        public enum ReturnReason
        {
            [Description("Normal Return")]
            NormalReturn = 1,
            [Description("Expensive Return")]
            ExpensiveReturn = 2
        }

        public enum Prefix
        {
            [Description("Purchase Return")]
            PR,
            [Description("Purchasr Invoice")]
            PIINV,
            [Description("Sales Return")]
            SR,
            [Description("Stock In")]
            STKIN,
            [Description("Sales Invoice")]
            SIINV,
            [Description("Stock Out")]
            STKOUT
        }
        public enum Modules
        {
            AttributeMaster = 1,
            AttributeDetailMaster = 2,
            BrandMaster = 3,
            CategoryMaster = 4,
            CustomerMaster = 5,
            StoreMaster = 6,
            UserMaster = 7,
            SupplierMaster = 8,
            UnitMaster = 9,
            TaxMaster = 10,
            PrefixMaster = 11,
            ProductMaster = 12,
            StockIn = 13,
            StockOut = 14,
            PurchaseInvoice = 15,
            PurchaseReturn = 16,
            SalesInvoice = 17,
            SalesReturn = 18,
            SupplierPayment = 19
        }


    }


}
