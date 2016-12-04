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
    public class QuarterTests
    {
        [TestMethod()]
        public void QuarterTest()
        {
            Quarter quarter = null;
            Assert.IsNull(quarter);

            quarter = new Quarter();

            Assert.IsNotNull(quarter);
            Assert.AreEqual(5.67M, quarter.Weight);
            Assert.AreEqual(24.26M, quarter.Diameter);
            Assert.AreEqual(1.75M, quarter.Thickness);
            Assert.AreEqual(.25M, quarter.Value);
        }
    }
}