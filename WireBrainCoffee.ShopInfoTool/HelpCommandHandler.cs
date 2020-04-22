using System;
using System.Collections.Generic;
using WiredBrainCoffee.DataAccess.Model;

namespace WireBrainCoffee.ShopInfoTool
{
    internal class HelpCommandHandler : ICommandHandler
    {
        private IEnumerable<CoffeeShop> coffeeShops;

        public HelpCommandHandler(IEnumerable<CoffeeShop> coffeeShops)
        {
            this.coffeeShops = coffeeShops;
        }

        public void HandlerCommand()
        {
            Console.WriteLine("> Available coffee shop commands, write 'quit' to exit application");

            foreach (var coffeeShop in coffeeShops)
            {
                Console.WriteLine($"> {coffeeShop.Location}");
            }
        }
    }
}