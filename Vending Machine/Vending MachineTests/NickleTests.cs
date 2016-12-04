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
    public class NickleTests
    {
        [TestMethod()]
        public void NickleTest()
        {
            Nickle nickle = null;
            Assert.IsNull(nickle);

            nickle = new Nickle();

            Assert.IsNotNull(nickle);
            Assert.AreEqual(5.0M, nickle.Weight);
            Assert.AreEqual(21.21M, nickle.Diameter);
            Assert.AreEqual(1.95M, nickle.Thickness);
            Assert.AreEqual(.05M, nickle.Value);
        }
    }
}