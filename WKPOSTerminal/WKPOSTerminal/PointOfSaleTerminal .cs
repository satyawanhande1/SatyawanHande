using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WKPOSTerminal.Models;

namespace WKPOSTerminal
{
     // Created interface for standarad POS operations
    public interface POS
    {
        Product ProductScan(string productCode);
        double SingleProduct(string productCode, int numberOfItems);
        double PackOfThree(string productCode, int numberOfItems, double discount);
        double PackOfSix(string productCode, int numberOfItems, double discount);

    }

    // Implementing the interface
    public class PointOfSaleTerminal : POS
    {
        List<Product> Products = new List<Product>()
        {
            new Product()
                {
                    ProductCode = "A", Price = 1.25, DiscountType = "PackOfThree"
                },
            new Product()
                {
                    ProductCode = "B", Price = 4.25, DiscountType = "SingleProduct"
                },
            new Product()
                {
                    ProductCode = "C", Price = 1.00, DiscountType = "PackOfSix"
                },
            new Product()
                {
                    ProductCode = "D", Price = 0.75, DiscountType = "SingleProduct"
                },

        };

        public Product ProductScan(string prod)
        {
            var productdetails = Products.Single(i => i.ProductCode == prod);

            return productdetails;
        }

        public double SingleProduct(string productCode, int numberOfItems)
        {
            double productPrice = Products.Single(x => x.ProductCode == productCode).Price;
            return (productPrice * numberOfItems);
        }

        public double PackOfThree(string productCode, int numberOfItems, double discount)
        {
            double productPrice = Products.Single(x => x.ProductCode == productCode).Price;
            return (productPrice * numberOfItems) - (discount * (numberOfItems / 3));
        }

        public double PackOfSix(string productCode, int numberOfItems, double discount)
        {
            double productPrice = Products.Single(x => x.ProductCode == productCode).Price;
            return (productPrice * numberOfItems) - (discount * (numberOfItems / 6));
        }
    }

}