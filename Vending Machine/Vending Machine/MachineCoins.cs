﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class MachineCoins
    {
        const int numCoins = 2;

        /// <summary>
        /// A list to keep track of the coins in the machine
        /// </summary>
        public List<Coin> CoinsInMachine { get; private set; }

        /// <summary>
        /// Constructs a machine coins object
        /// </summary>
        public MachineCoins()
        {
            CoinsInMachine = new List<Coin>();
        }

        /// <summary>
        /// Refills the machine with coins, up to the max number of coins
        /// </summary>
        public void RefillCoins()
        {
            int nickelCount = 0;
            int dimeCount = 0;
            int quarterCount = 0;

            //Determine the number each coin to be added
            foreach (var item in CoinsInMachine)
            {
                if (item.GetType() == typeof(Nickel))
                    nickelCount++;
                else if (item.GetType() == typeof(Dime))
                    dimeCount++;
                else if (item.GetType() == typeof(Quarter))
                    quarterCount++;
            }

            for (int i = 0; i < numCoins; i++)
            {
                if (nickelCount < numCoins)
                {
                    Nickel nickel = new Nickel();
                    CoinsInMachine.Add(nickel);
                    nickelCount++;
                }

                if (dimeCount < numCoins)
                {
                    Dime dime = new Dime();
                    CoinsInMachine.Add(dime);
                    dimeCount++;
                }

                if (quarterCount < numCoins)
                {
                    Quarter quarter = new Quarter();
                    CoinsInMachine.Add(quarter);
                    quarterCount++;
                }
            }
        }

        /// <summary>
        /// Returns a coin to the customer
        /// </summary>
        /// <param name="coin">The coin to be refunded</param>
        public void RefundCoin(Coin coin)
        {
            foreach (var item in CoinsInMachine)
            {
                if (item.GetType() == coin.GetType())
                {
                    CoinsInMachine.Remove(item);
                    break;
                }
            }
        }
    }
}
