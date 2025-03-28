using hamaraBasket.Factories;
using hamaraBasket.Models;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace hamaraBasket.Tests
{
    [TestFixture]
    public class InteractionTests
    {
        private DomainFactory factory;

        [SetUp]
        public void Setup()
        {
            factory = new DomainFactory();
        }

        [Test]
        public void UpdateQuality_ShouldCallUpdateQualityOnAllItems()
        {
            // Arrange
            var mockItem1 = new Mock<Item>("TestItem1", 10, 20) { CallBase = true };
            var mockItem2 = new Mock<Item>("TestItem2", 5, 30) { CallBase = true };
            var items = new List<Item> { mockItem1.Object, mockItem2.Object };
            var basket = new HamaraBasket(items);

            // Act
            basket.UpdateQuality();

            // Assert
            mockItem1.Verify(item => item.UpdateItemDetails(), Times.Once);
            mockItem2.Verify(item => item.UpdateItemDetails(), Times.Once);
        }

        [Test]
        public void UpdateQuality_ShouldEnsureQualityIsWithinValidRange()
        {
            // Arrange
            var mockItem = new Mock<Item>("TestItem", 10, 55) { CallBase = true };
            var items = new List<Item> { mockItem.Object };
            var basket = new HamaraBasket(items);

            // Act
            basket.UpdateQuality();

            // Assert
            Assert.That(mockItem.Object.GetQuality(), Is.LessThanOrEqualTo(50)); // Ensures quality is within range
        }

    }
}