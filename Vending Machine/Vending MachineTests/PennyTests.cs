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
    public class PennyTests
    {
        [TestMethod()]
        public void PennyTest()
        {
            Penny penny = null;
            Assert.IsNull(penny);

            penny = new Penny();

            Assert.IsNotNull(penny);
            Assert.IsInstanceOfType(penny, typeof(Penny));

            Assert.AreEqual(2.5M, penny.Weight);
            Assert.AreEqual(19.05M, penny.Diameter);
            Assert.AreEqual(1.55M, penny.Thickness);
            Assert.AreEqual(.01M, penny.Value);
        }
    }
}