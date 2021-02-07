using BrightHR.Checkout.Models;
using System.Collections.Generic;

namespace BrightHR.Checkout
{
    public class Checkout : ICheckout
    {
        private IEnumerable<Product> _products;
        private IEnumerable<Offer> _Offers;

        private IEnumerable<string> _productsScanned;

        public Checkout()
        {

        }

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
