using System.Web.Mvc;

namespace IMS.Models.Products
{
    public class ProductSearchModel
    {
        public int ProductId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public SelectList ProductList { get; set; }
        public SelectList BrandList { get; set; }
        public SelectList CategoryList { get; set; }
    }
}