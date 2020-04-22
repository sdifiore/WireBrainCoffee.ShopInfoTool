using System;
using System.Collections.Generic;
using System.Linq;
using WiredBrainCoffee.DataAccess.Model;

namespace WireBrainCoffee.ShopInfoTool
{
    internal class CoffeShopCommandHandler : ICommandHandler
    {
        private IEnumerable<CoffeeShop> coffeeShops;
        private string line;

        public CoffeShopCommandHandler(IEnumerable<CoffeeShop> coffeeShops, string line)
        {
            this.coffeeShops = coffeeShops;
            this.line = line;
        }

        public void HandlerCommand()
        {
            var foundCoffeeShops = coffeeShops
                        .Where(x => x.Location.StartsWith(line, StringComparison.OrdinalIgnoreCase))
                        .ToList();

            if (foundCoffeeShops.Count == 0)
                Console.WriteLine($"> Command '{line}' not found");
            else if (foundCoffeeShops.Count == 1)
            {
                var coffeeShop = foundCoffeeShops.Single();
                Console.WriteLine($"> Location: {coffeeShop.Location}");
                Console.WriteLine($"> Beans in stock: {coffeeShop.BeansInStock} kg");
            }
            else
            {
                Console.WriteLine("> Multiple matching coffee shope comands found:");

                foreach (var coffeType in foundCoffeeShops)
                {
                    Console.WriteLine($"> {coffeType.Location}");
                }
            }
        }
    }
}