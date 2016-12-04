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

            Assert.Fail();
        }

        [TestMethod()]
        public void RefillCoinsTest()
        {
            //TODO: Add code to empty coins so refill can be tested
            Assert.Fail();
        }
    }
}