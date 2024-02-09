using Xunit;
using System;

namespace SupermarketProject.Test
{
    public class CheckoutTests
    {
        private readonly IPricing pricing = new PricingImpl();
        private readonly IOffers offers = new OffersImpl();
        private readonly TotalPriceCalculator totalPriceCalculator = new TotalPriceCalculator();
        private readonly Checkout checkout;

        public CheckoutTests()
        {
            checkout = new Checkout(totalPriceCalculator);
        }

        [Theory]
        [InlineData("", 0)]
        [InlineData("A", 50)]
        [InlineData("AA", 100)]
        [InlineData("AAA", 130)]
        [InlineData("AAAB", 160)]
        [InlineData("AAABB", 175)]
        [InlineData("AAABBC", 195)]
        public void SingleItemPriceTest(string input, int expectedTotalPrice)
        {
            Assert.Equal(expectedTotalPrice, checkout.CalculateTotalPrice(input, pricing, offers));
        }

        [Theory]
        [InlineData("ABCD", 115)]
        [InlineData("AAAAAA", 260)]
        [InlineData("ABBAA", 175)]
        public void MixedItemsWithSpecialOffersTest(string input, int expectedTotalPrice)
        {
            Assert.Equal(expectedTotalPrice, checkout.CalculateTotalPrice(input, pricing, offers));
        }

        
        [Theory]
        [InlineData("XYZ", typeof(ArgumentException))] // Invalid SKU, expecting ArgumentException
        [InlineData("ABCDZ", typeof(ArgumentException))] // Invalid SKU combination, expecting ArgumentException
        public void InvalidInputTest(string input, Type expectedExceptionType)
        {
            Assert.Throws(expectedExceptionType, () => checkout.CalculateTotalPrice(input, pricing, offers));
        }

    }
}