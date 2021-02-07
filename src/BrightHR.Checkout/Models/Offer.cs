namespace BrightHR.Checkout.Models
{
    public class Offer
    {
        public string Sku { get; set; }
        public int Quantity { get; set; }
        public decimal Discount { get; set; }

        public Offer()
        {

        }

        public Offer(string sku, int quantity, decimal discount)
        {
            Sku = sku;
            Quantity = quantity;
            Discount = discount;
        }
    }
}