using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class CustomerCoins
    {
        public List<Coin> InsertedCoins { get; set; }

        public decimal Value()
        {
            decimal total = 0;

            foreach (var coin in InsertedCoins)
                total += coin.Value;

            return total;
        }
    }
}
