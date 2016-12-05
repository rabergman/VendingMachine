using System.Collections.Generic;

namespace Vending_Machine
{
    public class Machine
    {
        const int numProducts = 2;

        /// <summary>
        /// A list to keep track of the products in the machine
        /// </summary>
        public List<Products> ProductsInInventory { get; private set; }

        /// <summary>
        /// An Object to keep track of the coins in the machine
        /// </summary>
        public MachineCoins CoinsInInventory { get; private set; }

        /// <summary>
        /// An object to keep track of the coins inserted by the customer
        /// </summary>
        public CustomerCoins CoinsInserted { get; private set; }

        /// <summary>
        /// Used to determine if exact change only is required
        /// </summary>
        public bool ExactChangeOnly { get; set; }

        /// <summary>
        /// Determines if any of the products are sold out
        /// </summary>
        /// <returns>A list with the sold out items</returns>
        public List<Products> FindSoldOutProducts()
        {
            List<Products> soldOuts = new List<Products>();

            int colaCount = 0, chipsCount = 0, candyCount = 0;
            foreach (var item in ProductsInInventory)
            {
                if (item.GetType() == typeof(Cola))
                    colaCount++;
                else if (item.GetType() == typeof(Chips))
                    chipsCount++;
                else if (item.GetType() == typeof(Candy))
                    candyCount++;
            }

            if (colaCount == 0)
                soldOuts.Add(new Cola());

            if (chipsCount == 0)
                soldOuts.Add(new Chips());

            if (candyCount == 0)
                soldOuts.Add(new Candy());

            return soldOuts;
        }

        /// <summary>
        /// A string to hold the current display text
        /// </summary>
        public string DisplayText { get; set; }

        /// <summary>
        /// When a new machine is created is filled with a set number
        /// of each product and a set number of each coin
        /// </summary>
        public Machine()
        {
            ProductsInInventory = new List<Products>();
            CoinsInInventory = new MachineCoins();
            CoinsInserted = new CustomerCoins();

            RefillProduct();
            CoinsInInventory.RefillCoins();

            SetDisplayText("INSERT COINS");
        }

        /// <summary>
        /// Refill all products in the machine, up to the max number of products
        /// </summary>
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

        /// <summary>
        /// Removes either a coin or a product from their respective lists
        /// </summary>
        /// <typeparam name="T">The type of the item</typeparam>
        /// <param name="item">The item to be removed</param>
        /// <returns>True if successful, else false</returns>
        public bool RemoveItem<T>(T item)
        {
            bool returnValue = false;

            if (item.GetType().BaseType == typeof(Products))
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
                foreach (var coin in CoinsInInventory.CoinsInMachine)
                {
                    if (coin.GetType() == item.GetType())
                    {
                        CoinsInInventory.CoinsInMachine.Remove(coin);
                        returnValue = true;
                        break;
                    }
                }
            }

            return returnValue;
        }

        /// <summary>
        /// Accepts coins from customers
        /// </summary>
        /// <param name="coin">The coin inserted</param>
        /// <returns>The value of the coins inserted</returns>
        public decimal InsertCoin(Coin coin)
        {
            if (coin.ValidCoin())
                CoinsInserted.AddCoin(coin);

            SetDisplayText(CoinsInserted.Value().ToString("C"));

            return CoinsInserted.Value();
        }

        /// <summary>
        /// Refunds the customers money
        /// </summary>
        /// <returns>True if refund was successful, else false</returns>
        public void RefundMoney()
        {
            CoinsInserted.RefundCoins();
        }

        /// <summary>
        /// Removes the product from inventory and makes change
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public bool PurchaseItem(Products product)
        {
            bool success = false;

            foreach (var item in ProductsInInventory)
            {
                if (ExactChangeOnly)
                {
                    if (item.GetType() == product.GetType() &&
                    CoinsInserted.Value() == item.Price)
                    {
                        success = ProductsInInventory.Remove(item);
                        break;
                    }
                }
                else if (item.GetType() == product.GetType() &&
                    CoinsInserted.Value() >= item.Price)
                {
                    success = ProductsInInventory.Remove(item);
                    MakeChange(product.Price);
                    break;
                }
            }

            if (success)
                SetDisplayText("THANK YOU!");
            else
            {
                if (ExactChangeOnly)
                    SetDisplayText("EXACT CHANGE ONLY");
                else
                    SetDisplayText(product.Price.ToString("C"));
            }

            return success;
        }

        /// <summary>
        /// Makes change for a customer
        /// </summary>
        /// <param name="purchasePrice">The price of the item purchased</param>
        /// <returns>A list with the coins to be returned to the customer</returns>
        public List<Coin> MakeChange(decimal purchasePrice)
        {
            List<Coin> moneyToReturn = new List<Coin>();

            if (CoinsInserted.Value() >= purchasePrice)
            {
                decimal amountOver = CoinsInserted.Value() - purchasePrice;

                CoinsInserted.MoveCoinsToBin();

                Quarter quarter = new Quarter();
                while (quarter.Value <= amountOver)
                {
                    CoinsInInventory.RefundCoin(quarter);
                    amountOver = amountOver - quarter.Value;
                    moneyToReturn.Add(quarter);
                }

                Dime dime = new Dime();
                while (dime.Value <= amountOver)
                {
                    CoinsInInventory.RefundCoin(dime);
                    amountOver = amountOver - dime.Value;
                    moneyToReturn.Add(dime);
                }

                Nickel nickel = new Nickel();
                while (nickel.Value <= amountOver)
                {
                    CoinsInInventory.RefundCoin(nickel);
                    amountOver = amountOver - dime.Value;
                    moneyToReturn.Add(nickel);
                }
            }

            if (CoinsInInventory.MissingCoins().Count > 0)
                ExactChangeOnly = true;

            return moneyToReturn;
        }

        /// <summary>
        /// Setup the text for the display
        /// </summary>
        /// <param name="text">The text to display</param>
        public void SetDisplayText(string text)
        {
            if (ExactChangeOnly && text == "INSERT COINS")
                DisplayText = "EXACT CHANGE ONLY";
            else
                DisplayText = text;
        }
    }
}
