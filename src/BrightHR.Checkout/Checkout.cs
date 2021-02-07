using BrightHR.Checkout.Models;
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
            var products = _products.Where(p => _scannedProducts.Any(sp => p.Sku == sp));
            return products.Sum(p => p.UnitPrice);
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
    }
}
