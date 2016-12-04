using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class CustomerCoins
    {
        private List<Coin> InsertedCoins { get; set; }

        public CustomerCoins()
        {
            InsertedCoins = new List<Coin>();
        }

        public decimal AddCoin(Coin coin)
        {
            InsertedCoins.Add(coin);
            return Value();
        }

        public decimal Value()
        {
            decimal total = 0;

            foreach (var coin in InsertedCoins)
                total += coin.Value;

            return total;
        }

        public int CoinCount()
        {
            return InsertedCoins.Count();
        }

        //This is primarily here for testing
        public void CheckCoinCount(out int nickelCount,
            out int dimeCount, out int quarterCount)
        {
            nickelCount = 0;
            dimeCount = 0;
            quarterCount = 0;

            //Determine the number of each coin in inventory
            foreach (var item in InsertedCoins)
            {
                if (item.GetType() == typeof(Nickel))
                    nickelCount++;
                else if (item.GetType() == typeof(Dime))
                    dimeCount++;
                else if (item.GetType() == typeof(Quarter))
                    quarterCount++;
            }
        }


        private bool ValidateCoin(Coin coin)
        {
            bool returnValue = false;

            return returnValue;
        }
    }
}
