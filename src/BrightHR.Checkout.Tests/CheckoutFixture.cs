using BrightHR.Checkout.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace BrightHR.Checkout.Tests
{
    public class CheckoutFixture
    {
        private IEnumerable<Product> _products;
        private IEnumerable<Offer> _offers;

        public CheckoutFixture()
        {
            _products = new List<Product>
            {
                new Product("A", 50m),
                new Product("B", 30m),
                new Product("C", 20m),
                new Product("D", 15m),
            };

            _offers = new List<Offer>
            {
                new Offer("A", 3, 130m),
                new Offer("B", 2, 45m),
            };
        }
    }
}
