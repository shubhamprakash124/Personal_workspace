namespace hamaraBasket.Models 
{
    public class Item {
        private string name;
        private int sellIn;
        private int quality;

        public Item(string name, int sellIn, int quality) {
            this.name = name;
            ValidateAndSetItemDetails(sellIn, quality);
        }

        private void ValidateAndSetItemDetails(int sellIn, int quality) {
            if(quality < 0) {
                this.quality = 0;
            }
            else if (quality > 50) {
                this.quality = 50;
            }
            else {
                this.quality = quality;
            }

            if(sellIn < 0) {
                this.sellIn = 0;
            }
            else {
                this.sellIn = sellIn;
            }
        }

        public string GetName() {
            return name;
        }

        public int GetSellIn() {
            return sellIn;
        }

        public int GetQuality() {
            return quality;
        }

        public void SetName(string name) {
            this.name = name;
        }

        public void SetSellIn(int sellIn) {
            this.sellIn = sellIn;
        }

        public void SetQuality(int quality) {
            this.quality = quality;
        }

        public virtual void UpdateItemDetails()
        {
            if (this.GetQuality() > 0 && this.GetSellIn() != 0)
            {
                this.SetQuality(this.GetQuality() - 1);
                this.SetSellIn(this.GetSellIn() - 1);
            }
            else if (this.GetQuality() > 0 && this.GetSellIn() == 0)
            {
                this.SetQuality(this.GetQuality() - 2);
            }
        }

        override
        public string ToString() {
            return this.name + " - " + this.sellIn + " - " + this.quality;
        }
    }
}