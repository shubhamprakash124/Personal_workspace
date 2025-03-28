using hamaraBasket.Models;
namespace hamaraBasket.Factories
{
    public class DomainFactory
    {
        public IList<Item> PrepareSingleItem(string name, int sellIn, int quality)
        {
            List<Item> items = [];
            switch(name)
            {
                case "Movie Tickets":
                    items = [new MovieTicket(sellIn, quality)];
                    break;
                case "Indian Wine":
                    items = [new IndianWine(sellIn, quality)];
                    break;
                case "Forest Honey":
                    items = [new ForestHoney(sellIn, quality)];
                    break;
                default:
                    items = [new Item(name, sellIn, quality)];
                    break;
            }
            return items;
        }

        public void InitAndUpdateRules(IList<Item> items)
        {
            HamaraBasket basket = new HamaraBasket(items);
            basket.UpdateQuality();
        }
    }
}
