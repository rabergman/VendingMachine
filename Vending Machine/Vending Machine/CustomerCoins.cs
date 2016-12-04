using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class CustomerCoins
    {
        /// <summary>
        /// A list to hold the coins the customer has inserted
        /// </summary>
        private List<Coin> InsertedCoins { get; set; }

        /// <summary>
        /// The coins the customer has inserted
        /// </summary>
        public CustomerCoins()
        {
            InsertedCoins = new List<Coin>();
        }

        /// <summary>
        /// Adds a coin to the inserted coins list
        /// </summary>
        /// <param name="coin">The coin to be inserted</param>
        /// <returns>The value of the coins the customer has inserted</returns>
        public decimal AddCoin(Coin coin)
        {
            InsertedCoins.Add(coin);
            return Value();
        }

        /// <summary>
        /// Gets the value of the coins the customer has added
        /// </summary>
        /// <returns>The value of the coins the customer has inserted</returns>
        public decimal Value()
        {
            decimal total = 0;

            foreach (var coin in InsertedCoins)
                total += coin.Value;

            return total;
        }

        /// <summary>
        /// Gets the total number of coins the customer has inserted
        /// </summary>
        /// <returns>The number of coins the customer has inserted</returns>
        public int CoinCount()
        {
            return InsertedCoins.Count();
        }

        /// <summary>
        /// This is for testing purposes only
        /// </summary>
        /// <param name="nickelCount">The number of nickels the customer has inserted</param>
        /// <param name="dimeCount">The number of dimes the customer has inserted</param>
        /// <param name="quarterCount">The number of quarters the customer has inserted</param>
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

        /// <summary>
        /// Validates the coin inserted
        /// </summary>
        /// <param name="coin">The coin to be validated</param>
        /// <returns>True if the coin is valid, else false</returns>
        private bool ValidateCoin(Coin coin)
        {
            bool returnValue = false;

            if (coin.GetType() == typeof(Penny))
                returnValue = false;
            else if (coin.GetType() == typeof(Nickel))
                returnValue = true;
            else if (coin.GetType() == typeof(Dime))
                returnValue = true;
            else if (coin.GetType() == typeof(Quarter))
                returnValue = true;

            return returnValue;
        }

        /// <summary>
        /// Refund all the coins the customer inserted
        /// </summary>
        public void RefundCoins()
        {
            InsertedCoins.Clear();
        }

        /// <summary>
        /// Move all the customers coins to the bin
        /// </summary>
        public void MoveCoinsToBin()
        {
            InsertedCoins.Clear();
        }
    }
}
