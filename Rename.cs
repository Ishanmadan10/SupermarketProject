using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    public class Checkout
    {
        private readonly TotalPriceCalculator totalPriceCalculator;

        public Checkout(TotalPriceCalculator totalPriceCalculator)
        {
            this.totalPriceCalculator = totalPriceCalculator;
        }

        public int CalculateTotalPrice(string input, IPricing pricing, IOffers offers)
        {
            var itemCounts = new Dictionary<char, int>();

            foreach (char sku in input.ToUpper())
            {
                if (Char.IsLetter(sku))
                {
                    if (itemCounts.ContainsKey(sku))
                    {
                        itemCounts[sku]++;
                    }
                    else
                    {
                        itemCounts[sku] = 1;
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid character '{sku}'. Skipping.");
                }
            }

            return totalPriceCalculator.CalculateTotalPrice(itemCounts, pricing, offers);
        }
    }

}
