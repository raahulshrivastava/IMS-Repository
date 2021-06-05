using IMS.DataContext;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IMS.Models.Attributes
{
    public class GridModel : IPagedList
    {
        public int PageCount { get; set; }

        public int TotalItemCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public bool HasPreviousPage { get; set; }

        public bool HasNextPage { get; set; }

        public bool IsFirstPage { get; set; }

        public bool IsLastPage { get; set; }

        public int FirstItemOnPage { get; set; }

        public int LastItemOnPage { get; set; }

        public PagedList<AttributeMaster> AttributeList { get; set; }
    }
}