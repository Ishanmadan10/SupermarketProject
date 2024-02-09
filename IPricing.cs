using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketProject
{
    public interface IPricing
    {
        int GetPrice(char sku);
    }

}
