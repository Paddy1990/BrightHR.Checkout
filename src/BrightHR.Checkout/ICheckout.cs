﻿namespace BrightHR.Checkout
{
    public interface ICheckout
    {
        void Scan(string item);
        int GetTotalPrice();
    }
}