using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.IsInstanceOfType(quarter, typeof(Quarter));

            Assert.AreEqual(5.67M, quarter.Weight);
            Assert.AreEqual(24.26M, quarter.Diameter);
            Assert.AreEqual(1.75M, quarter.Thickness);
            Assert.AreEqual(.25M, quarter.Value);
        }
    }
}