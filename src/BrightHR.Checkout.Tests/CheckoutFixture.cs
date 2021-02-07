using BrightHR.Checkout.Models;
using Should;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

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
            _checkout.ScannedProducts.Count.ShouldEqual(1);
            _checkout.ScannedProducts.ShouldContain(sku);
        }

        [Fact]
        public void Scan_Returns_Early_When_Item_Null_Or_Empty()
        {
            //Arrange
            var sku = string.Empty;

            //Act
            _checkout.Scan(sku);

            //Assert
            _checkout.ScannedProducts.Count.ShouldEqual(0);
        }

        [Fact]
        public void Scan_Throws_When_Sku_Missing_In_Products()
        {
            //Arrange
            var sku = "E";

            //Act
            var exception = Assert.Throws<KeyNotFoundException>(() => _checkout.Scan(sku));

            //Assert
            exception.Message.ShouldEqual($"The Product with SKU {sku} does not exist in the system.");

            _checkout.ScannedProducts.Count.ShouldEqual(0);
            _checkout.ScannedProducts.ShouldNotContain(sku);
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
