using System.Collections.Generic;

namespace BrightHR.Checkout
{
    public interface ICheckout
    {
        public IList<string> ScannedProducts { get; }

        void Scan(string item);
        int GetTotalPrice();
    }
}
