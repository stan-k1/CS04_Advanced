using System;

namespace Lab1_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Product product = new Product() {Name = "Smartphone", Price = 1000m};
            product.PriceUpdated += PriceIncreaseHandler;
            product.PriceUpdated += PriceDecreaseHandler;

            product.Price = 1500m;
            product.Price = 1200m;
        }

        public static void PriceIncreaseHandler(object sender, PriceUpdateEventArgs e)
        {
            if (e.CurPrice>e.OldPrice)
                Console.WriteLine($"Price of product {e.ProdName} increased from {e.OldPrice} to {e.CurPrice}!");
        }

        public static void PriceDecreaseHandler(object sender, PriceUpdateEventArgs e)
        {
            if (e.CurPrice < e.OldPrice)
                Console.WriteLine($"Price of product {e.ProdName} decreased to {e.CurPrice} from {e.OldPrice}!");
        }
    }
}
