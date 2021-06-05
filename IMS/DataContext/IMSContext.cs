using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace IMS.DataContext
{
    public partial class IMSContext : DbContext
    {
        public IMSContext() : base("name=DBIMS")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            modelBuilder.Entity<AttributeDetailMaster>().ToTable("StoreMaster");
            modelBuilder.Entity<AttributeDetailMaster>().ToTable("AttributeDetailMaster");
            modelBuilder.Entity<AttributeMaster>().ToTable("AttributeMaster");
            modelBuilder.Entity<BrandMaster>().ToTable("BrandMaster");
            modelBuilder.Entity<CategoryMaster>().ToTable("CategoryMaster");
            modelBuilder.Entity<CustomerMaster>().ToTable("CustomerMaster");
            modelBuilder.Entity<LogTable>().ToTable("LogTables");
            modelBuilder.Entity<PrefixMaster>().ToTable("PrefixMaster");
            modelBuilder.Entity<ProductMasterDetail>().ToTable("ProductMasterDetail");
            modelBuilder.Entity<ProductMasterHeader>().ToTable("ProductMasterHeader");
            modelBuilder.Entity<PurchaseInvoiceDetail>().ToTable("PurchaseInvoiceDetail");
            modelBuilder.Entity<PurchaseInvReturnDetail>().ToTable("PurchaseInvReturnDetail");
            modelBuilder.Entity<PurchaseReturnHeader>().ToTable("PurchaseReturnHeader");
            modelBuilder.Entity<PurchaserInvoiceHeader>().ToTable("PurchaserInvoiceHeader");
            modelBuilder.Entity<SalesInvoice>().ToTable("SalesInvoice");
            modelBuilder.Entity<SalesInvoiceDetail>().ToTable("SalesInvoiceDetail");
            modelBuilder.Entity<SalesInvoiceReturnDetail>().ToTable("SalesInvoiceReturnDetail");
            modelBuilder.Entity<SalesInvoiceReturnHeader>().ToTable("SalesInvoiceReturnHeader");
            modelBuilder.Entity<StockInDetailMaster>().ToTable("StockInDetailMaster");
            modelBuilder.Entity<StockInHeaderMaster>().ToTable("StockInHeaderMaster");
            modelBuilder.Entity<StockOutDetailMaster>().ToTable("StockOutDetailMaster");
            modelBuilder.Entity<StockOutHeader>().ToTable("StockOutHeader");
            modelBuilder.Entity<StoreMaster>().ToTable("StoreMaster");
            modelBuilder.Entity<SupplierMaster>().ToTable("SupplierMaster");
            modelBuilder.Entity<TaxMaster>().ToTable("TaxMaster");
            modelBuilder.Entity<TblConfiguration>().ToTable("TblConfiguration");
            modelBuilder.Entity<TblParameter>().ToTable("TblParameter");
            modelBuilder.Entity<TblRole>().ToTable("TblRole");
            modelBuilder.Entity<UnitMaster>().ToTable("UnitMaster");
            modelBuilder.Entity<UserDetail>().ToTable("UserDetail");
            modelBuilder.Entity<UserMaster>().ToTable("UserMaster");
            modelBuilder.Entity<UserTable>().ToTable("UserTable");
            modelBuilder.Entity<SupplierPayment>().ToTable("SupplierPayment");
            modelBuilder.Entity<CustomerPayment>().ToTable("CustomerPayment");
        }

        public virtual DbSet<AttributeDetailMaster> AttributeDetailMasters { get; set; }
        public virtual DbSet<AttributeMaster> AttributeMasters { get; set; }
        public virtual DbSet<BrandMaster> BrandMasters { get; set; }
        public virtual DbSet<CategoryMaster> CategoryMasters { get; set; }
        public virtual DbSet<CustomerMaster> CustomerMasters { get; set; }
        public virtual DbSet<LogTable> LogTables { get; set; }
        public virtual DbSet<PrefixMaster> PrefixMasters { get; set; }
        public virtual DbSet<ProductMasterDetail> ProductMasterDetails { get; set; }
        public virtual DbSet<ProductMasterHeader> ProductMasterHeaders { get; set; }
        public virtual DbSet<PurchaseInvoiceDetail> PurchaseInvoiceDetails { get; set; }
        public virtual DbSet<PurchaseInvReturnDetail> PurchaseInvReturnDetails { get; set; }
        public virtual DbSet<PurchaseReturnHeader> PurchaseReturnHeaders { get; set; }
        public virtual DbSet<PurchaserInvoiceHeader> PurchaserInvoiceHeaders { get; set; }
        public virtual DbSet<SalesInvoice> SalesInvoices { get; set; }
        public virtual DbSet<SalesInvoiceDetail> SalesInvoiceDetails { get; set; }
        public virtual DbSet<SalesInvoiceReturnDetail> SalesInvoiceReturnDetails { get; set; }
        public virtual DbSet<SalesInvoiceReturnHeader> SalesInvoiceReturnHeaders { get; set; }
        public virtual DbSet<StockInDetailMaster> StockInDetailMasters { get; set; }
        public virtual DbSet<StockInHeaderMaster> StockInHeaderMasters { get; set; }
        public virtual DbSet<StockOutDetailMaster> StockOutDetailMasters { get; set; }
        public virtual DbSet<StockOutHeader> StockOutHeaders { get; set; }
        public virtual DbSet<StoreMaster> StoreMasters { get; set; }
        public virtual DbSet<SupplierMaster> SupplierMasters { get; set; }
        public virtual DbSet<TaxMaster> TaxMasters { get; set; }
        public virtual DbSet<TblConfiguration> TblConfigurations { get; set; }
        public virtual DbSet<TblParameter> TblParameters { get; set; }
        public virtual DbSet<TblRole> TblRoles { get; set; }
        public virtual DbSet<UnitMaster> UnitMasters { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }
        public virtual DbSet<UserMaster> UserMasters { get; set; }
        public virtual DbSet<UserTable> UserTables { get; set; }
        public virtual DbSet<SupplierPayment> SupplierPayments { get; set; }
        public virtual DbSet<CustomerPayment> CustomerPayments { get; set; }
    }


}