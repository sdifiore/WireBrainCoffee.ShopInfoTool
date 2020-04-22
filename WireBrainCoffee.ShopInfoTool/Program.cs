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

                var commandHandler = string.Equals("help", line, StringComparison.OrdinalIgnoreCase)
                    ? new HelpCommandHandler(coffeeShops) as ICommandHandler
                    : new CoffeShopCommandHandler(coffeeShops, line);

                commandHandler.HandlerCommand();
            }
        }
    }
}
