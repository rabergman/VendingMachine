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
    public class ValidateCoinTests
    {
        [TestMethod()]
        public void ValidCoinTest()
        {
            Machine machine = new Machine();

            Assert.AreEqual(.05M, machine.InsertCoin(new Nickel()));
            Assert.AreEqual(.05M, machine.InsertCoin(new Nickel(4.0M)));

            Assert.AreEqual(.15M, machine.InsertCoin(new Dime()));
            Assert.AreEqual(.15M, machine.InsertCoin(new Dime(17.01M)));

            Assert.AreEqual(.40M, machine.InsertCoin(new Quarter()));
            Assert.AreEqual(.40M, machine.InsertCoin(new Quarter(1.85M)));
        }
    }
}