using NUnit.Framework;
using Sample1;
using System.Collections.Generic;

namespace UnitTest
{
    public class Tests
    {
        [Test]
        public void UserProductCheckout()
        {
            Dictionary<string, int> Product = new Dictionary<string, int>();
            Product.Add("A", 3);
            Product.Add("B", 5);
            Product.Add("C", 1);
            Product.Add("D", 1);

            PromotionEngine obj = new User();
            int totalCost = obj.Checkout(Product);
            Assert.AreEqual(280, totalCost);
        }

        
    }
}