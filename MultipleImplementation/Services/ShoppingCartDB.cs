﻿using MultipleImplementation.Interfaces;

namespace MultipleImplementation.Services
{
    public class ShoppingCartDB : IShoppingCart
    {
        public object GetCart()
        {
            return "Cart loaded from DB";
        }
    }
}