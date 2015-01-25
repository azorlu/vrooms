using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Vrooms.WebUI.Models;

namespace Vrooms.WebUI.HtmlHelpers
{
    public static class PaginationHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, Pagination pagination, Func<int, string> pageUrl)
        {
            StringBuilder links = new StringBuilder();
            for (int i = 1; i <= pagination.TotalPagesNum; i++)
            {
                TagBuilder tb = new TagBuilder("a");
                tb.MergeAttribute("href", pageUrl(i));
                tb.InnerHtml = i.ToString();

                if (i == pagination.CurrentPageNum)
                {
                    tb.AddCssClass("selected");
                    tb.AddCssClass("btn-primary");
                }

                tb.AddCssClass("btn btn-default");
                links.Append(tb.ToString());
            }

            return MvcHtmlString.Create(links.ToString());
        }
    }
}