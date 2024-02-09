namespace SupermarketProject
{
    class Program
    {
        static void Main(string[] args)
        {
            var pricing = new PricingImpl();
            var offers = new OffersImpl();
            var totalPriceCalculator = new TotalPriceCalculator();
            var checkout = new Checkout(totalPriceCalculator);

            Console.WriteLine("Enter the items (e.g., AABBCC): ");
            string input = Console.ReadLine();

            int totalPrice = checkout.CalculateTotalPrice(input, pricing, offers);
            Console.WriteLine("Total Price: " + totalPrice);
        }
    }
}
