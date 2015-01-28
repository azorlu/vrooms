using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vrooms.Domain.Entities;

namespace Vrooms.WebUI.Models
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}