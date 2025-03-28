using hamaraBasket.Factories;
using hamaraBasket.Models;

namespace hamaraBasket
{
    [TestFixture]
    public class HamaraBasketTest
    {
        private DomainFactory? factory;

        [SetUp]
        public void Setup()
        {
            factory = new DomainFactory();
        }

        [Test]
        public void GenericItemSellByShouldReduceByOne()
        {
            string name = "Lux Soap";
            int sellIn = 10;
            int quality = 10;
            IList<Item> items = factory.PrepareSingleItem(name, sellIn, quality);
            factory.InitAndUpdateRules(items);
            Assert.That(items[0].GetSellIn(), Is.EqualTo(sellIn - 1));
        }

        [Test]
        public void GenericItemQualityShouldReduceByOne()
        {
            string name = "Lux Soap";
            int sellIn = 10;
            int quality = 10;
            IList<Item> items = factory.PrepareSingleItem(name, sellIn, quality);
            factory.InitAndUpdateRules(items);
            Assert.That(items[0].GetQuality(), Is.EqualTo(quality - 1));
        }

        //  Once the sell by date has passed, Quality degrades twice as fast
        [Test]
        public void GenericItemQualityShouldReduceByTwoAfterSellByDate()
        {
            string name = "Lux Soap";
            int sellIn = 0;
            int quality = 1;
            IList<Item> items = factory.PrepareSingleItem(name, sellIn, quality);
            factory.InitAndUpdateRules(items);
            Assert.That(items[0].GetQuality(), Is.EqualTo(quality - 2), "Quality should reduce by 2 after sell by date");
        }

        // WHen the quality of an item is greater than 50, it should be set to 50
        [Test]
        public void GenericItemQualityShouldNotBeNegative()
        {
            string name = "Lux Soap";
            int sellIn = 0;
            int quality = 0;
            IList<Item> items = factory.PrepareSingleItem(name, sellIn, quality);
            factory.InitAndUpdateRules(items);
            Assert.That(items[0].GetQuality(), Is.EqualTo(0), "Quality should not be negative");
        }

        // "Indian Wine" actually increases in Quality the older it gets
        [Test]
        public void IndianWineQualityShouldIncrease()
        {
            string name = "Indian Wine";
            int sellIn = 10;
            int quality = 45;
            IList<Item> items = factory.PrepareSingleItem(name, sellIn, quality);
            factory.InitAndUpdateRules(items);
            Assert.That(items[0].GetQuality(), Is.EqualTo(quality + 1), "Indian Wine quality should increase by 1");
        }

        // The Quality of an item is never more than 50 --------> Defect
        [Test]
        public void IndianWineQualityShouldNotBeMoreThan50()
        {
            string name = "Indian Wine";
            int sellIn = 10;
            int quality = 60;
            IList<Item> items = factory.PrepareSingleItem(name, sellIn, quality);
            factory.InitAndUpdateRules(items);
            Assert.That(items[0].GetQuality(), Is.EqualTo(50), "Indian Wine quality should not be more than 50");
        }

        // "Forest Honey", being a legendary item, never has to be sold or decreases in Quality
        [Test]
        public void ForestHoneyQualityShouldNotChange()
        {
            string name = "Forest Honey";
            int sellIn = 10;
            int quality = 10;
            IList<Item> items = factory.PrepareSingleItem(name, sellIn, quality);
            factory.InitAndUpdateRules(items);
            Assert.That(items[0].GetQuality(), Is.EqualTo(quality), "Forest Honey quality should not change");
        }

        // "Movie Tickets ", like Indian Wine, increases in Quality as its SellBy value approaches;
        [Test]
        public void MovieTicketsQualityShouldIncreaseByTwoWhenSellInIs10OrLess()
        {
            string name = "Movie Tickets";
            int sellIn = 10;
            int quality = 10;
            IList<Item> items = factory.PrepareSingleItem(name, sellIn, quality);
            factory.InitAndUpdateRules(items);
            Assert.That(items[0].GetQuality(), Is.EqualTo(quality + 2), "Movie Tickets quality should increase by 2 when sellIn is 10 or less");
        }

        // "Movie Tickets", quality increases by 3 when there are 5 days or less
        [Test]
        public void MovieTicketsQualityShouldIncreaseByThreeWhenSellInIs5OrLess()
        {
            string name = "Movie Tickets";
            int sellIn = 5;
            int quality = 10;
            IList<Item> items = factory.PrepareSingleItem(name, sellIn, quality);
            factory.InitAndUpdateRules(items);
            Assert.That(items[0].GetQuality(), Is.EqualTo(quality + 3), "Movie Tickets quality should increase by 3 when sellIn is 5 or less");
        }

        // "Movie Tickets", quality drops to 0 after the Show
        [Test]
        public void MovieTicketsQualityShouldBeZeroAfterShow()
        {
            string name = "Movie Tickets";
            int sellIn = 0;
            int quality = 10;
            IList<Item> items = factory.PrepareSingleItem(name, sellIn, quality);
            factory.InitAndUpdateRules(items);
            Assert.That(items[0].GetQuality(), Is.EqualTo(0), "Movie Tickets quality should be 0 after show");
        }

        [TearDown]
        public void Teardown()
        {
            factory = null;
        }
    }
}
