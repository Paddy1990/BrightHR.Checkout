using BrightHR.Checkout.Models;
using System.Collections.Generic;

namespace BrightHR.Checkout
{
    public class Checkout : ICheckout
    {
        private IEnumerable<Product> _products;
        private IEnumerable<Offer> _Offers;

        private IList<string> _scannedProducts;

        public Checkout(IEnumerable<Product> products, IEnumerable<Offer> offers)
        {
            _products = products;
            _Offers = offers;

            _scannedProducts = new List<string>();
        }

        public IList<string> ScannedProducts { get => _scannedProducts; }

        public int GetTotalPrice()
        {
            throw new System.NotImplementedException();
        }

        public void Scan(string item)
        {
            _scannedProducts.Add(item);
        }
    }
}
