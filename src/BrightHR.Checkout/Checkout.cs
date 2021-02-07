using BrightHR.Checkout.Models;
using System.Collections.Generic;

namespace BrightHR.Checkout
{
    public class Checkout : ICheckout
    {
        private IEnumerable<Product> _products;
        private IEnumerable<Offer> _Offers;

        private IEnumerable<string> _scannedProducts;

        public Checkout(IEnumerable<Product> products, IEnumerable<Offer> offers)
        {
            _products = products;
            _Offers = offers;
        }

        public IEnumerable<string> ScannedProducts { get => _scannedProducts; }

        public int GetTotalPrice()
        {
            throw new System.NotImplementedException();
        }

        public void Scan(string item)
        {
            throw new System.NotImplementedException();
        }
    }
}
