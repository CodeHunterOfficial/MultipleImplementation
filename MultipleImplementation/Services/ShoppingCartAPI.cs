﻿using MultipleImplementation.Interfaces;

namespace MultipleImplementation.Services
{
    public class ShoppingCartAPI: IShoppingCart
    {
        public object GetCart()
        {
            return "Cart loaded through API.";
        }
    }
}