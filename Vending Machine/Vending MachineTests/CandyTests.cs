using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.IsInstanceOfType(candy, typeof(Candy));

            Assert.AreEqual("Candy", candy.Name);
            Assert.AreEqual(.65M, candy.Price);
        }
    }
}