using System;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Xml.Serialization;
using FreemiumGameShop.Client;
using Microsoft.Owin.Hosting;

namespace FreemiumGameShop.Main
{
    internal class ExampleTool
    {
        public void Example1()
        {
            var cs = new Client.ClientService();
            var custs = new Customer.CustomerService();
            var sis = new ClientItem.ClientItemService();
            cs.CreateClient("First shop");
            ClientService.AddCustomer(1, 1000);
            ClientService.AddCustomer(1, 1000);
            ClientService.AddItem(1, "Emperor's sword", "asdgdi", 500);
            ClientService.AddItem(1, "The Book of Magnus", "ygfoewrg", 120);
            ClientService.AddItem(1, "Sword of phoenix", "sabgoiswbvg", 400);

            string i1 = sis.GetCode(1, "Emperor's sword");
            string i2 = sis.GetCode(1, "The Book of Magnus");
            string i3 = sis.GetCode(1, "Sword of phoenix");

            custs.ItemPurchase(1, 1, i1);
            custs.ItemPurchase(1, 1, i2);
            custs.ItemPurchase(1, 2, i3);
        }

        public void Example2()
        {
            var cs = new Client.ClientService();
            var custs = new Customer.CustomerService();
            var sis = new ClientItem.ClientItemService();
            cs.CreateClient("First shop");
            ClientService.AddCustomer(1, 1000);
            ClientService.AddCustomer(1, 1000);
            ClientService.AddItem(1, "Emperor's sword", "asdgdi", 500);
            ClientService.AddItem(1, "The Book of Magnus", "ygfoewrg", 120);
            ClientService.AddItem(1, "Sword of phoenix", "sabgoiswbvg", 400);

         /*   string i1 = sis.GetCode(1, "Emperor's sword");
            string i2 = sis.GetCode(1, "The Book of Magnus");
            String i3 = sis.GetCode(1, "Sword of phoenix");

            custs.ItemPurchase(1, 1, i1);
            custs.ItemPurchase(1, 1, i2);
            custs.ItemPurchase(1, 2, i3);

    */
            string address = "http://localhost:9000/";

            using (WebApp.Start<Startup.Startup>(address))
            {
                HttpClient client = new HttpClient();

                var resp1 = client.GetAsync(address + "client/1/get_customer/1").Result;
                var resp2 = client.GetAsync(address + "client/1/get_customer/2").Result;

                Console.WriteLine(resp1.Content.ReadAsStringAsync().Result);
                Console.WriteLine(resp2.Content.ReadAsStringAsync().Result);
            }

            Console.ReadKey();
        }

        public void ShowAll()
        {
            using (DataAccess.ShopContext sctx = new DataAccess.ShopContext())
            {
                var clients = from cl in sctx.Clients.Include(i => i.Items).Include(c => c.Customers)
                              select cl;

                foreach (var client in clients)
                {
                    Console.WriteLine(client.Name + " :: " + client.Id + " :: Customer List:");
                    var customers = client.Customers.ToList();
                    foreach (var c in client.Customers)
                    {
                        Console.WriteLine(c.Id + " :: Ammount :: " + c.Ammount + "$$ :: Inventory:");

                        var inventoryList = sctx.Set<DataAccess.CustomerItem>().Where(i => i.CustomerId == c.Id).ToList();

                        foreach (var i in inventoryList)
                        {
                            Console.WriteLine("----------" + i.Name);
                        }
                    }
                }
            }
        }
    }
}