using System.Collections.Generic;
using hamaraBasket.Models;

namespace hamaraBasket
{
    public class HamaraBasket
    {
        IList<Item> Items;
        public HamaraBasket(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.GetQuality() > 50)
                {
                    continue;
                }
                item.UpdateItemDetails();
            }
        }
    }
}
