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
    public class ColaTests
    {
        [TestMethod()]
        public void ColaTest()
        {
            Cola cola = null;
            Assert.IsNull(cola);

            cola = new Cola();
            Assert.IsNotNull(cola);
            Assert.IsInstanceOfType(cola, typeof(Cola));

            Assert.AreEqual("Cola", cola.Name);
            Assert.AreEqual(1.00M, cola.Price);
        }
    }
}