using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vrooms.Domain.Entities;

namespace Vrooms.WebUI.Models
{
    public class LanguagesListViewModel
    {
        public IEnumerable<SelectListItem> LanguagesList { get; set; }
        public string SelectedLanguageId { get; set; }
    }
}