using System;
using System.Linq;
namespace FreemiumGameShop.MainAttributes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var cs = new Client.ClientService();
            var custs = new Customer.CustomerService();
            var sis = new ShopItem.ShopItemService();
            cs.CreateClient("First shop");
            cs.AddCustomer(1, 1000);
            cs.AddCustomer(1, 1000);
            cs.AddItem(1, "Emperor's sword", "asdgdi", 500);
            cs.AddItem(1, "The Book of Magnus", "ygfoewrg", 120);
            cs.AddItem(1, "Sword of phoenix", "sabgoiswbvg", 400);
            string i1 = sis.GetCode(1, "Emperor's sword");
            string i2 = sis.GetCode(1, "The Book of Magnus");
            String i3 = sis.GetCode(1, "Sword of phoenix");

            custs.ItemPurchase(1, 1, i1);
            custs.ItemPurchase(1, 1, i2);
            custs.ItemPurchase(1, 2, i3);

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
