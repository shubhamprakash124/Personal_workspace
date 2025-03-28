namespace hamaraBasket.Models
{
    public class MovieTicket : Item
    {
        public MovieTicket(int sellIn, int quality) : base("Movie Tickets", sellIn, quality) { }

        override
        public void UpdateItemDetails()
        {
            if (GetSellIn() == 0)
            {
                SetQuality(0);
            }
            else if (GetQuality() < 50 && GetSellIn() <= 5)
            {
                SetQuality(GetQuality() + 3);
                SetSellIn(GetSellIn() - 1);
            }
            else if (GetQuality() < 50 && GetSellIn() <= 10)
            {
                SetQuality(GetQuality() + 2);
                SetSellIn(GetSellIn() - 1);
            }
        }
    }
}