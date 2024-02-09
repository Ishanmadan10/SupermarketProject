using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    public class TotalPriceCalculator
    {
        public int CalculateTotalPrice(Dictionary<char, int> itemCounts, IPricing pricing, IOffers offers)
        {
            int totalPrice = 0;
            foreach (var item in itemCounts)
            {
                char sku = item.Key;
                int quantity = item.Value;

                if (offers.HasOffer(sku))
                {
                    var offer = offers.GetOffer(sku);
                    int offerQuantity = offer.Item1;
                    int offerPrice = offer.Item2;
                    int normalPrice = pricing.GetPrice(sku);

                    int offerCount = quantity / offerQuantity; // Number of times offer applies
                    int remainingCount = quantity % offerQuantity; // Remaining items after applying offer

                    // Calculate total price considering the offer and remaining items
                    totalPrice += offerCount * offerPrice + remainingCount * normalPrice;
                }
                else
                {
                    // If no offer, calculate total price based on normal price
                    totalPrice += pricing.GetPrice(sku) * quantity;
                }
            }
            return totalPrice;
        }
    }
}
