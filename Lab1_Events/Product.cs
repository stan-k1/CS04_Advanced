using System;

namespace Lab1_Events
{
    class Product
    {
        private decimal price;
        public string Name { get; set; }
        public decimal Price
        {
            get => price;
            set
            {
                if (value == price) return;
                decimal prevPrice = price;
                price = value;
                OnPriceChanged(price, prevPrice);
            }
        }

        public event EventHandler<PriceUpdateEventArgs> PriceUpdated;

        public void OnPriceChanged(decimal curPrice, decimal oldPrice)
        {
            PriceUpdated?.Invoke(this, new(Name, curPrice, oldPrice));
        }

    }

    public class PriceUpdateEventArgs : EventArgs
    {
        public string ProdName;
        public decimal CurPrice;
        public decimal OldPrice;
        
        public PriceUpdateEventArgs(string prodName, decimal curPrice, decimal oldPrice)
        {
            ProdName = prodName;
            CurPrice = curPrice;
            OldPrice = oldPrice;
        }
    }
}
