namespace hamaraBasket.Models
{
    public class IndianWine : Item
    {
        public IndianWine(int sellIn, int quality) : base("Indian Wine", sellIn, quality) { }

        override
        public void UpdateItemDetails()
        {
            if (GetQuality() < 50 && GetSellIn() != 0)
            {
                SetQuality(GetQuality() + 1);
                SetSellIn(GetSellIn() - 1);
            }
        }
    }
}