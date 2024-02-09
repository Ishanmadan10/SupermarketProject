using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    public interface IOffers
    {
        bool HasOffer(char sku);
        Tuple<int, int> GetOffer(char sku);
    }
}
