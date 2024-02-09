using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    public class OffersImpl : IOffers
    {
        private readonly Dictionary<char, Tuple<int, int>> offers = new Dictionary<char, Tuple<int, int>> {
        {'A', Tuple.Create(3, 130)},
        {'B', Tuple.Create(2, 45)}
    };

        public bool HasOffer(char sku)
        {
            return offers.ContainsKey(sku);
        }

        public Tuple<int, int> GetOffer(char sku)
        {
            if (HasOffer(sku))
            {
                return offers[sku];
            }
            throw new ArgumentException($"Offer for SKU '{sku}' not found.");
        }
    }

}
