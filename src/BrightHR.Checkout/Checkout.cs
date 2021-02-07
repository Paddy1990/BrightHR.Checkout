using BrightHR.Checkout.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrightHR.Checkout
{
    public class Checkout : ICheckout
    {
        private IEnumerable<Product> _products;
        private IEnumerable<Offer> _offers;

        private IList<string> _scannedProducts;

        public Checkout(IEnumerable<Product> products, IEnumerable<Offer> offers)
        {
            _products = products;
            _offers = offers;

            _scannedProducts = new List<string>();
        }

        public IList<string> ScannedProducts { get => _scannedProducts; }

        public decimal GetTotalPrice()
        {
            var products = _products.Where(product => _scannedProducts.Any(scannedProduct => product.Sku == scannedProduct));
            var offers = _offers.Where(offer => _scannedProducts.Any(scannedProduct => offer.Sku == scannedProduct));

            var total = _scannedProducts.Sum(scannedProduct => GetUnitPrice(scannedProduct, products));
            var totalDiscount = offers.Sum(offer => CalculateOfferDiscount(offer));

            return total - totalDiscount;
        }

        public void Scan(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                //Log the fact we have a null or empty item passed in!
                return;
            }

            if (!_products.Any(p => p.Sku == item))
            {
                //Log the fact we have a null or empty item passed in!
                return;
            }

            _scannedProducts.Add(item);
        }

        private static decimal GetUnitPrice(string scannedProduct, IEnumerable<Product> products)
        {
            var product = products.First(product => product.Sku == scannedProduct);
            return product.UnitPrice;
        }

        private decimal CalculateOfferDiscount(Offer offer)
        {
            var productCount = _scannedProducts.Count(scannedProduct => offer.Sku == scannedProduct);
            return (productCount / offer.Quantity) * offer.Discount;
        }

    }
}
