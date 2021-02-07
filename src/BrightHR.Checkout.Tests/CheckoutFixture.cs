using BrightHR.Checkout.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;
using Xunit.Should;

namespace BrightHR.Checkout.Tests
{
    public class CheckoutFixture
    {
        private IEnumerable<Product> _products;
        private IEnumerable<Offer> _offers;

        private readonly Checkout _checkout;

        public CheckoutFixture()
        {
            SetupProductsData();
            SetupOffersData();

            _checkout = new Checkout(_products, _offers);
        }

        [Fact]
        public void Scan_Adds_To_ScannedProducts()
        {
            //Arrange
            var sku = "A";

            //Act
            _checkout.Scan(sku);

            //Assert
            _checkout.ScannedProducts.ShouldContain(sku);
        }


        private void SetupOffersData()
        {
            _offers = new List<Offer>
            {
                new Offer("A", 3, 130m),
                new Offer("B", 2, 45m),
            };
        }

        private void SetupProductsData()
        {
            _products = new List<Product>
            {
                new Product("A", 50m),
                new Product("B", 30m),
                new Product("C", 20m),
                new Product("D", 15m),
            };
        }

    }
}
