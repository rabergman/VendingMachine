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

        [TestMethod]
        public void SelectColaTest()
        {
            Machine machine = new Machine();

            machine.RemoveItem<Cola>(new Cola());


            Assert.Fail();
        }

        [TestMethod]
        public void SelectChipsTest()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void SelectCandyTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void RefillProductsTest()
        {
            Machine machine = new Machine();

            RemoveProduct(machine);

            CheckProductCount(machine);
        }

        [TestMethod()]
        public void RefillCoinsTest()
        {
            Machine machine = new Machine();

            RemoveCoins(machine);

            machine.RefillCoins();

            CheckCoinCount(machine);
        }

        private void RemoveCoins(Machine machine)
        {
            machine.RemoveItem<Coin>(new Nickel());
            machine.RemoveItem<Coin>(new Nickel());
            machine.RemoveItem<Coin>(new Dime());
            machine.RemoveItem<Coin>(new Quarter());
        }

        private void RemoveProduct(Machine machine)
        {
            machine.RemoveItem<Product>(new Chips());
            machine.RemoveItem<Product>(new Cola());
            machine.RemoveItem<Product>(new Cola());
            machine.RemoveItem<Product>(new Candy());
        }

        private void CheckProductCount(Machine machine)
        {
            int chipCount = 0, colaCount = 0, candyCount = 0;

            //Determine the number of each product in inventory
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

        private void CheckCoinCount(Machine machine)
        {
            int nickelCount = 0, dimeCount = 0, quarterCount = 0;

            //Determine the number of each coin in inventory
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
    }
}