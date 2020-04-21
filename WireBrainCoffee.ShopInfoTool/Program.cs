using System;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using WiredBrainCoffee.DataAccess.Model;

namespace WireBrainCoffee.ShopInfoTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wired Brain Coffee - Shop Info Tool!");

            Console.WriteLine("Write 'help' to list available coffee shop comands, write 'quit' to exit the application");

            var coffeeShopDataProvider = new CoffeeShopDataProvider();

            while (true)
            {
                var line = Console.ReadLine();

                if (string.Equals("quit", line, StringComparison.OrdinalIgnoreCase))
                    break;

                var coffeeShops = coffeeShopDataProvider.LoadCoffeeShops();

                if (string.Equals("help", line, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("> Available coffee shop commands, write 'quit' to exit application");

                    foreach (var coffeeShop in coffeeShops)
                    {
                        Console.WriteLine($"> {coffeeShop.Location}");
                    }
                }

                else
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
    }
}
