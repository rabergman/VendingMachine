using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine
{
    public class Machine
    {
        const int numProducts = 2;
        const int numCoins = 2;

        /// <summary>
        /// A list to keep track of the products in the machine
        /// </summary>
        public List<Product> ProductsInInventory { get; private set; }

        /// <summary>
        /// A list to keep track of the coins in the machine
        /// </summary>
        public List<Coin> CoinsInInventory { get; private set; }

        /// <summary>
        /// When a new machine is created is filled with a set number
        /// of each product and a set number of each coin
        /// </summary>
        public Machine()
        {
            this.ProductsInInventory = new List<Product>();
            this.CoinsInInventory = new List<Coin>();

            RefillProduct();
            RefillCoins();
        }

        public void RefillProduct()
        {
            int chipCount = 0;
            int colaCount = 0;
            int candyCount = 0;

            //Determine the number of each product to be added
            foreach (var item in ProductsInInventory)
            {
                if (item.GetType() == typeof(Chips))
                    chipCount++;
                else if (item.GetType() == typeof(Cola))
                    colaCount++;
                else if (item.GetType() == typeof(Candy))
                    candyCount++;
            }

            for (int i = 0; i < numProducts; i++)
            {
                if (chipCount < numProducts)
                {
                    Chips chips = new Chips();
                    ProductsInInventory.Add(chips);
                    chipCount++;
                }

                if (colaCount < numProducts)
                {
                    Cola cola = new Cola();
                    ProductsInInventory.Add(cola);
                    colaCount++;
                }

                if (candyCount < numProducts)
                {
                    Candy candy = new Candy();
                    ProductsInInventory.Add(candy);
                    candyCount++;
                }
            }
        }

        public void RefillCoins()
        {
            int nickelCount = 0;
            int dimeCount = 0;
            int quarterCount = 0;

            //Determine the number each coin to be added
            foreach (var item in CoinsInInventory)
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
                    CoinsInInventory.Add(nickel);
                    nickelCount++;
                }

                if (dimeCount < numCoins)
                {
                    Dime dime = new Dime();
                    CoinsInInventory.Add(dime);
                    dimeCount++;
                }

                if (quarterCount < numCoins)
                {
                    Quarter quarter = new Quarter();
                    CoinsInInventory.Add(quarter);
                    quarterCount++;
                }
            }
        }

        /// <summary>
        /// Removes either a coin or a product from their respective lists
        /// </summary>
        /// <typeparam name="T">The type of the item</typeparam>
        /// <param name="item">The item to be removed</param>
        /// <returns>True if successful, else false</returns>
        public bool RemoveItem<T>(T item)
        {
            bool returnValue = false;

            if (item.GetType().BaseType == typeof(Product))
            {
                foreach (var prod in ProductsInInventory)
                {
                    if (prod.GetType() == item.GetType())
                    {
                        ProductsInInventory.Remove(prod);
                        returnValue = true;
                        break;
                    }
                }
            }
            else if (item.GetType().BaseType == typeof(Coin))
            {
                foreach (var coin in CoinsInInventory)
                {
                    if (coin.GetType() == item.GetType())
                    {
                        CoinsInInventory.Remove(coin);
                        returnValue = true;
                        break;
                    }
                }
            }

            return returnValue;
        }
    }
}
