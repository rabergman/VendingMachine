using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending_Machine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vending_Machine.Tests
{
    [TestClass()]
    public class MachineTests
    {
        const int numProducts = 2;
        const int numCoins = 2;

        [TestMethod()]
        public void MachineTest()
        {
            Machine machine = null;
            Assert.IsNull(machine);

            machine = new Machine();
            Assert.IsNotNull(machine);
            Assert.IsInstanceOfType(machine, typeof(Machine));
        }

        [TestMethod()]
        public void RefillProductTest()
        {
            Machine machine = new Machine();

            //TODO: Add code to empty products so refill can be tested

            int chipCount = 0;
            int colaCount = 0;
            int candyCount = 0;

            //Determine the number of each product to be added
            foreach (var item in machine.ProductsInInventory)
            {
                if (item.GetType() == typeof(Chips))
                    chipCount++;
                else if (item.GetType() == typeof(Cola))
                    colaCount++;
                else if (item.GetType() == typeof(Candy))
                    candyCount++;
            }

            Assert.AreEqual(numProducts, chipCount);
            Assert.AreEqual(numProducts, colaCount);
            Assert.AreEqual(numProducts, candyCount);
        }

        [TestMethod()]
        public void RefillCoinsTest()
        {
            Machine machine = new Machine();

            //TODO: Add code to empty coins so refill can be tested
            RemoveCoins(machine);

            int nickelCount = 0;
            int dimeCount = 0;
            int quarterCount = 0;

            //Determine the number of each coin to be added
            foreach (var item in machine.CoinsInInventory)
            {
                if (item.GetType() == typeof(Nickel))
                    nickelCount++;
                else if (item.GetType() == typeof(Dime))
                    dimeCount++;
                else if (item.GetType() == typeof(Quarter))
                    quarterCount++;
            }

            Assert.AreEqual(numCoins, nickelCount);
            Assert.AreEqual(numCoins, dimeCount);
            Assert.AreEqual(numCoins, quarterCount);
        }

        private void RemoveCoins(Machine machine)
        {
            machine.RemoveItem<Coin>(new Nickel());
        }
    }
}