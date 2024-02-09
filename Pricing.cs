using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    public class PricingImpl : IPricing
    {
        private readonly Dictionary<char, int> prices = new Dictionary<char, int> {
        {'A', 50},
        {'B', 30},
        {'C', 20},
        {'D', 15}
    };

        public int GetPrice(char sku)
        {
            if (prices.ContainsKey(sku))
            {
                return prices[sku];
            }
            throw new ArgumentException($"Price for SKU '{sku}' not found.");
        }
    }
}
