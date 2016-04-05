using NUnit.Framework;
using Moq;
using Services.DomainObjects;
using Services;

namespace Tests.Unit
{
    public class CheckoutTests
    {
        private ICheckoutService checkout;

        private readonly Item itemA = new Item
        {
            Id = 1,
            Name = "A",
            Price = 50
        };

        private readonly Item itemB = new Item
        {
            Id = 2,
            Name = "B",
            Price = 30
        };

        [SetUp]
        public void SetUp()
        {
            checkout = new CheckoutService();
        }

        private void AddItems(int count,
                              Item item)
        {
            for (int i = 0;
                 i < count;
                 i++)
            {
                checkout.AddItem(item);
            }
        }

        [Test]
        public void TestCheckoutZeroItemReturnsZero()
        {
            long result = checkout.CalculateTotal();

            Assert.AreEqual(0,
                            result);
        }

        [Test]
        public void TestCheckoutOneItemsPriceAsTotal()
        {
            AddItems(1,
                     itemA);

            long result = checkout.CalculateTotal();
            Assert.AreEqual(50,
                            result);
        }

        [Test]
        public void TestCheckoutTwoItemsPriceAsTotal()
        {
            AddItems(1,
                     itemA);

            AddItems(2,
                     itemB);

            long result = checkout.CalculateTotal();
            Assert.AreEqual(110,
                            result);
        }
    }
}
