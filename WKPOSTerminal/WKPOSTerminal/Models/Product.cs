using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WKPOSTerminal.Models
{
    public class Product
    {
        public string ProductCode { get; set; }
        public double Price { get; set; }

        public string DiscountType { get; set; }
    }
}