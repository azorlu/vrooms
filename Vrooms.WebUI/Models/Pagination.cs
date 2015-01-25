using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vrooms.WebUI.Models
{
    public class Pagination
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPageNum { get; set; }
        public int TotalPagesNum
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}