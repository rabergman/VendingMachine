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
    public class CandyTests
    {
        [TestMethod()]
        public void CandyTest()
        {
            Candy candy = null;
            Assert.IsNull(candy);

            candy = new Candy();
            Assert.IsNotNull(candy);

            Assert.AreEqual("Candy", candy.Name);
            Assert.AreEqual(.65M, candy.Price);
        }
    }
}