using System.Collections.Generic;
using IMS.Business;
namespace IMS.Models.Products
{
    public class ProductReportViewModel
    {
        public ProductReportViewModel()
        {
            this.ProductList = new List<ProductMasterModel>();
        }
        public List<ProductMasterModel> ProductList { get; set; }
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string BrandName { get; set; }
    }
}