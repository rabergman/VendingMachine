using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
        public void AddCoinTest()
        {
            Machine machine = new Machine();

            Assert.AreEqual(0, machine.CoinsInserted.CoinCount());

            machine.CoinsInserted.AddCoin(new Nickel());

            Assert.AreEqual(1, machine.CoinsInserted.CoinCount());

            int nickelCount, dimeCount, quarterCount;

            machine.CoinsInserted.CheckCoinCount(
                out nickelCount, out dimeCount, out quarterCount);

            Assert.AreEqual(1, nickelCount);
            Assert.AreEqual(0, dimeCount);
            Assert.AreEqual(0, quarterCount);
        }

        [TestMethod]
        public void SelectColaTest()
        {
            Machine machine = new Machine();

            Assert.IsTrue(machine.RemoveItem(new Cola()));

            int chipCount, colaCount, candyCount;

            CheckProductCount(machine, out chipCount, out colaCount,
                out candyCount);

            Assert.AreEqual(numProducts, chipCount);
            Assert.AreEqual(numProducts - 1, colaCount);
            Assert.AreEqual(numProducts, candyCount);
        }

        [TestMethod]
        public void SelectChipsTest()
        {
            Machine machine = new Machine();

            Assert.IsTrue(machine.RemoveItem(new Chips()));

            int chipCount, colaCount, candyCount;

            CheckProductCount(machine, out chipCount, out colaCount,
                out candyCount);

            Assert.AreEqual(numProducts - 1, chipCount);
            Assert.AreEqual(numProducts, colaCount);
            Assert.AreEqual(numProducts, candyCount);
        }

        [TestMethod]
        public void SelectCandyTest()
        {
            Machine machine = new Machine();

            Assert.IsTrue(machine.RemoveItem(new Candy()));

            int chipCount, colaCount, candyCount;

            CheckProductCount(machine, out chipCount, out colaCount,
                out candyCount);

            Assert.AreEqual(numProducts, chipCount);
            Assert.AreEqual(numProducts, colaCount);
            Assert.AreEqual(numProducts - 1, candyCount);
        }

        [TestMethod]
        public void DispenseNickelTest()
        {
            Machine machine = new Machine();

            Assert.IsTrue(machine.RemoveItem(new Nickel()));

            int nickelCount, dimeCount, quarterCount;

            CheckMachineCoinCount(machine, out nickelCount,
                out dimeCount, out quarterCount);

            Assert.AreEqual(numCoins - 1, nickelCount);
            Assert.AreEqual(numCoins, dimeCount);
            Assert.AreEqual(numCoins, quarterCount);
        }

        [TestMethod]
        public void DispenseDimeTest()
        {
            Machine machine = new Machine();

            Assert.IsTrue(machine.RemoveItem(new Dime()));

            int nickelCount, dimeCount, quarterCount;

            CheckMachineCoinCount(machine, out nickelCount,
                out dimeCount, out quarterCount);

            Assert.AreEqual(numCoins, nickelCount);
            Assert.AreEqual(numCoins - 1, dimeCount);
            Assert.AreEqual(numCoins, quarterCount);
        }

        [TestMethod]
        public void DispenseQuarterTest()
        {
            Machine machine = new Machine();

            Assert.IsTrue(machine.RemoveItem(new Quarter()));

            int nickelCount, dimeCount, quarterCount;

            CheckMachineCoinCount(machine, out nickelCount,
                out dimeCount, out quarterCount);

            Assert.AreEqual(numCoins, nickelCount);
            Assert.AreEqual(numCoins, dimeCount);
            Assert.AreEqual(numCoins - 1, quarterCount);
        }

        [TestMethod()]
        public void RefillProductsTest()
        {
            Machine machine = new Machine();

            RemoveProduct(machine);

            machine.RefillProduct();

            int chipCount, colaCount, candyCount;

            CheckProductCount(machine, out chipCount, out colaCount,
                out candyCount);

            Assert.AreEqual(numProducts, chipCount);
            Assert.AreEqual(numProducts, colaCount);
            Assert.AreEqual(numProducts, candyCount);
        }

        [TestMethod()]
        public void RefillCoinsTest()
        {
            Machine machine = new Machine();

            RemoveCoins(machine);

            machine.CoinsInInventory.RefillCoins();

            int nickelCount, dimeCount, quarterCount;

            CheckMachineCoinCount(machine, out nickelCount,
                out dimeCount, out quarterCount);

            Assert.AreEqual(numCoins, nickelCount);
            Assert.AreEqual(numCoins, dimeCount);
            Assert.AreEqual(numCoins, quarterCount);
        }

        [TestMethod()]
        public void InsertMoneyTest()
        {
            Machine machine = new Machine();

            Assert.AreEqual(.05M, machine.InsertCoin(new Nickel()));

            Assert.AreEqual(.15M, machine.InsertCoin(new Dime()));

            Assert.AreEqual(.40M, machine.InsertCoin(new Quarter()));
        }

        [TestMethod()]
        public void RefundMoneyTest()
        {
            Machine machine = new Machine();

            machine.InsertCoin(new Nickel());
            machine.InsertCoin(new Dime());
            machine.InsertCoin(new Quarter());

            machine.RefundMoney();

            Assert.AreEqual(0, machine.CoinsInserted.CoinCount());
            Assert.AreEqual(0, machine.CoinsInserted.Value());
        }

        [TestMethod()]
        public void MakeChangeTest()
        {
            Machine machine = new Machine();

            Assert.AreEqual(.25M, machine.InsertCoin(new Quarter()));
            Assert.AreEqual(.50M, machine.InsertCoin(new Quarter()));
            Assert.AreEqual(.75M, machine.InsertCoin(new Quarter()));

            Assert.IsTrue(machine.PurchaseItem(new Candy()));

            Assert.AreEqual(0, machine.CoinsInserted.CoinCount());

            int nickelCount, dimeCount, quarterCount;

            CheckMachineCoinCount(machine, out nickelCount,
                out dimeCount, out quarterCount);

            Assert.AreEqual(numCoins, nickelCount);
            Assert.AreEqual(numCoins - 1, dimeCount);
            Assert.AreEqual(numCoins, quarterCount);
        }

        [TestMethod()]
        public void FindSoldOutTest()
        {
            Machine machine = new Machine();

            Assert.AreEqual(.25M, machine.InsertCoin(new Quarter()));
            Assert.AreEqual(.50M, machine.InsertCoin(new Quarter()));

            Assert.IsTrue(machine.PurchaseItem(new Chips()));
            Assert.AreEqual(0, machine.CoinsInserted.CoinCount());

            Assert.AreEqual(.25M, machine.InsertCoin(new Quarter()));
            Assert.AreEqual(.50M, machine.InsertCoin(new Quarter()));

            Assert.IsTrue(machine.PurchaseItem(new Chips()));
            Assert.AreEqual(0, machine.CoinsInserted.CoinCount());

            List<Products> soldOut = machine.FindSoldOutProducts();
            Assert.AreEqual(1, soldOut.Count);
        }

        [TestMethod()]
        public void DetermineExactChangeOnly()
        {
            Machine machine = new Machine();

            Assert.AreEqual(.25M, machine.InsertCoin(new Quarter()));
            Assert.AreEqual(.50M, machine.InsertCoin(new Quarter()));
            Assert.AreEqual(.75M, machine.InsertCoin(new Quarter()));

            Assert.IsTrue(machine.PurchaseItem(new Chips()));
            Assert.AreEqual(0, machine.CoinsInserted.CoinCount());

            Assert.AreEqual(0, machine.CoinsInInventory.MissingCoins().Count);

            Assert.AreEqual(.25M, machine.InsertCoin(new Quarter()));
            Assert.AreEqual(.50M, machine.InsertCoin(new Quarter()));
            Assert.AreEqual(.75M, machine.InsertCoin(new Quarter()));

            Assert.IsTrue(machine.PurchaseItem(new Chips()));
            Assert.AreEqual(0, machine.CoinsInserted.CoinCount());

            Assert.AreEqual(1, machine.CoinsInInventory.MissingCoins().Count);

            machine.SetDisplayText("EXACT CHANGE ONLY");
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
            machine.RemoveItem<Products>(new Chips());
            machine.RemoveItem<Products>(new Cola());
            machine.RemoveItem<Products>(new Cola());
            machine.RemoveItem<Products>(new Candy());
        }

        private void CheckProductCount(Machine machine, out int chipCount,
            out int colaCount, out int candyCount)
        {
            chipCount = 0;
            colaCount = 0;
            candyCount = 0;

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
        }

        private void CheckMachineCoinCount(Machine machine, out int nickelCount,
            out int dimeCount, out int quarterCount)
        {
            nickelCount = 0;
            dimeCount = 0;
            quarterCount = 0;

            //Determine the number of each coin in inventory
            foreach (var item in machine.CoinsInInventory.CoinsInMachine)
            {
                if (item.GetType() == typeof(Nickel))
                    nickelCount++;
                else if (item.GetType() == typeof(Dime))
                    dimeCount++;
                else if (item.GetType() == typeof(Quarter))
                    quarterCount++;
            }
        }
    }
}