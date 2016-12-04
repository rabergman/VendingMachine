using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vending_Machine;

namespace Vending_MachineTests
{
    [TestClass]
    public class SelectProductTests
    {
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
    }
}
