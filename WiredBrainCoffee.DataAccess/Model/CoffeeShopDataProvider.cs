﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WiredBrainCoffee.DataAccess.Model
{
    public class CoffeeShopDataProvider
    {
        public IEnumerable<CoffeeShop> LoadCoffeeShops()
        {
            yield return new CoffeeShop { Location = "Frankfurt", BeansInStock = 107 };
            yield return new CoffeeShop { Location = "Freiburg", BeansInStock = 23 };
            yield return new CoffeeShop { Location = "Munic", BeansInStock = 56 };
        }
    }
}
