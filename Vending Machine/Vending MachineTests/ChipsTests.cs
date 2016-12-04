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
    public class ChipsTests
    {
        [TestMethod()]
        public void ChipsTest()
        {
            Chips chips = null;
            Assert.IsNull(chips);

            chips = new Chips();
            Assert.IsNotNull(chips);

            Assert.AreEqual("Chips", chips.Name);
            Assert.AreEqual(.50M, chips.Price);
        }
    }
}