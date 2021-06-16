using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WKPOSTerminal.Models;


namespace WKPOSTerminal.Controllers
{
    public class ValuesController : ApiController
    {


        // GET api/values/ABCD
        public string Get(string items)
        {
            PointOfSaleTerminal terminal = new PointOfSaleTerminal();

            IList<Product> cartProducts = new List<Product>();

            //Accept input and scan the products
            foreach (char ch in items)
            {
                cartProducts.Add(terminal.ProductScan(ch.ToString()));
            }


            //Get costing for scanned products and apply discount
            var prcodes = cartProducts.Select(x => x.ProductCode).Distinct();

            double totalPrice = 0;

            foreach (string prod in prcodes)
            {
                int totalProductCounts = cartProducts.Count(x => x.ProductCode == prod);
                string productdetails = cartProducts.FirstOrDefault(x => x.ProductCode == prod).DiscountType;

                switch (productdetails)
                {
                    case "PackOfThree":
                        totalPrice = totalPrice + terminal.PackOfThree(prod, totalProductCounts, 0.75);
                        break;
                    case "SingleProduct":
                        totalPrice = totalPrice + terminal.SingleProduct(prod, totalProductCounts);
                        break;
                    case "PackOfSix":
                        totalPrice = totalPrice + terminal.PackOfSix(prod, totalProductCounts, 1);
                        break;
                    default:
                        break;
                }

            }

            //Return total cost of cart products

            return totalPrice.ToString();

        }


    }
}
