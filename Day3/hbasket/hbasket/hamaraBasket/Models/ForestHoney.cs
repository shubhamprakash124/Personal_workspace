namespace hamaraBasket.Models
{
    public class ForestHoney : Item
    {
        public ForestHoney(int sellIn, int quality) : base("Forest Honey", sellIn, quality) { }

        override
        public void UpdateItemDetails()
        {
            if (GetQuality() < 50 && GetSellIn() != 0)
            {
                SetSellIn(GetSellIn() - 1);
            }
        }
    
    }
}