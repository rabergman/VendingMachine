using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.IsInstanceOfType(chips, typeof(Chips));

            Assert.AreEqual("Chips", chips.Name);
            Assert.AreEqual(.50M, chips.Price);
        }
    }
}