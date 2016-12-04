using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vending_Machine.Tests
{
    [TestClass()]
    public class NickelTests
    {
        [TestMethod()]
        public void NickelTest()
        {
            Nickel nickel = null;
            Assert.IsNull(nickel);

            nickel = new Nickel();

            Assert.IsNotNull(nickel);
            Assert.IsInstanceOfType(nickel, typeof(Nickel));

            Assert.AreEqual(5.0M, nickel.Weight);
            Assert.AreEqual(21.21M, nickel.Diameter);
            Assert.AreEqual(1.95M, nickel.Thickness);
            Assert.AreEqual(.05M, nickel.Value);
        }
    }
}