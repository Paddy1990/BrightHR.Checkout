using System.Collections.Generic;

namespace BrightHR.Checkout
{
    public interface ICheckout
    {
        public IEnumerable<string> ScannedProducts { get; }

        void Scan(string item);
        int GetTotalPrice();
    }
}
