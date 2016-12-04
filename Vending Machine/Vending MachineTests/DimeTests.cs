using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vending_Machine.Tests
{
    [TestClass()]
    public class DimeTests
    {
        [TestMethod()]
        public void DimeTest()
        {
            Dime dime = null;
            Assert.IsNull(dime);

            dime = new Dime();

            Assert.IsNotNull(dime);
            Assert.IsInstanceOfType(dime, typeof(Dime));

            Assert.AreEqual(2.268M, dime.Weight);
            Assert.AreEqual(17.91M, dime.Diameter);
            Assert.AreEqual(1.35M, dime.Thickness);
            Assert.AreEqual(.10M, dime.Value);
        }
    }
}