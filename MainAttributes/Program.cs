using System;
using System.Linq;
using Freemium.Game.Shop.Client;
using Freemium.Game.Shop.Customer;

namespace Freemium.Game.Shop.MainAttributes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var cs = new ClientService();
            cs.CreateClient("First shop");
            cs.AddCustomer(1, 1000);
            cs.AddCustomer(1, 1000);
            cs.AddItem(1, "Emperor's sword", 500);
            cs.AddItem(1, "The Book of Magnus", 120);
            cs.AddItem(1, "Sword of phoenix", 400);
            var custs = new CustomerService();

            custs.ItemPurchase(1, 1, "Emperor's sword");
            custs.ItemPurchase(1, 1, "The Book of Magnus");
            custs.ItemPurchase(1, 2, "Sword of phoenix");

            using (ShopContext sctx = new ShopContext())
            {
                Console.WriteLine(sctx.Clients.Count());
            }

            var u = new Utils();
            u.ShowAll();
            Console.ReadKey();
        }
    }
}
